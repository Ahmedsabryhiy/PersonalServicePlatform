using System; 
using System.Collections.Generic;
using  Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public partial class PersonServicePlatformContext : IdentityDbContext<ApplicationUser>
{
    public PersonServicePlatformContext()
    {
    }

    public PersonServicePlatformContext(DbContextOptions<PersonServicePlatformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBooking> TbBookings { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbPayment> TbPayments { get; set; }

    public virtual DbSet<TbProviderAvailability> TbProviderAvailabilities { get; set; }

    public virtual DbSet<TbProvider> TbProviders { get; set; }

    public virtual DbSet<TbReview> TbReviews { get; set; }

    public virtual DbSet<TbService> TbServices { get; set; }
    public virtual DbSet<TbNotification> TbNotifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TbBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbBookin__3214EC2713107B12");

            entity.ToTable("TbBooking");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbBooking_Customer");

            entity.HasOne(d => d.Provider).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbBooking_Provider");

            entity.HasOne(d => d.Service).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbBooking_Service");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbCatego__3214EC2797CE1D76");

            entity.ToTable("TbCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
        
            entity.HasKey(e => e.Id).HasName("PK__TbCustom__3214EC2705220D64");

            entity.ToTable("TbCustomerProfile");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<TbPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbPaymen__3214EC2743F3969E");

            entity.ToTable("TbPayment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.TbPayments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbPayment_Booking");
        });

        modelBuilder.Entity<TbProviderAvailability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbProvid__3214EC2719122032");

            entity.ToTable("TbProviderAvailability");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Provider).WithMany(p => p.TbProviderAvailabilities)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbAvailability_Provider");

            entity.HasOne(d => d.Service).WithMany(p => p.TbProviderAvailabilities)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbAvailability_Service");
        });

        modelBuilder.Entity<TbProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbProvid__3214EC27A6B788F9");

            entity.ToTable("TbProviderProfile");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.AverageRating).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(200);
            entity.Property(e => e.Specialty).HasMaxLength(100);
        });

        modelBuilder.Entity<TbReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbReview__3214EC27C18B28DB");

            entity.ToTable("TbReview");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.Booking).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbReview_Booking");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbReview_Customer");
        });

        modelBuilder.Entity<TbService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbServic__3214EC2796C3FA63");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.TbServices)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbServices_Category");

            entity.HasOne(d => d.Provider).WithMany(p => p.TbServices)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbServices_Provider");
        });
        modelBuilder.Entity<TbNotification>(entity =>
        {
            entity.HasOne(a => a.Customer).
            WithMany(a => a.Notifications)
            .HasForeignKey(a => a.CustomerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
