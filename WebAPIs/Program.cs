
using Application.Contracts;
using Application.MappingProfiles;
using Application.Services;
using Infrastructure.Context;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace WebAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<PersonServicePlatformContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            #region Serilog
            //serilog configuration
            Log.Logger = new LoggerConfiguration()


        .WriteTo.MSSqlServer(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
            tableName: "Log",
            autoCreateSqlTable: true)
        .CreateLogger();

            builder.Host.UseSerilog();
            #endregion
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
            #endregion
            //configuration for Automapper
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
