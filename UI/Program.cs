
using Application.Contracts;
using Application.MappingProfiles;
using Application.Services;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using UI.Services;



namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            builder.Services.AddDbContext<PersonServicePlatformContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<PersonServicePlatformContext>();
            Log.Logger = new LoggerConfiguration()


              .WriteTo.MSSqlServer(
                  connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                  tableName: "Log",
                  autoCreateSqlTable: true)
              .CreateLogger();

            builder.Host.UseSerilog();
            #region  Register repositories and services
            // Register repositories and services
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IProviderService, ProviderService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IProviderAvailabilityService, ProviderAvailabilityService>();
            builder.Services.AddScoped<IServicesService, ServicesService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion
            //configuration for Automapper
            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();





            #region Routing
#pragma warning disable ASP0014 // Suggest using top level route registrations
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}");



                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");




            }
            );
#pragma warning restore ASP0014 // Suggest using top level route registrations
            #endregion
            using (var scope = app.Services.CreateScope())
            {
              var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
               var  roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var dbcontext = services.GetRequiredService<PersonServicePlatformContext>();
                await  dbcontext.Database.MigrateAsync();
                await ContextConfig.SeedDataAsync(dbcontext, userManager, roleManager);
            }

          await   app.RunAsync();
        }
    }
}
