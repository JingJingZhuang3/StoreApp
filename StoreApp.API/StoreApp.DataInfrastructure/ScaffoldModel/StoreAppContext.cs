using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreApp.DataInfrastructure
{
    public partial class StoreAppContext : DbContext
    {
        public StoreAppContext()
        {
        }

        public StoreAppContext(DbContextOptions<StoreAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<StoreInventory> StoreInventories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName).HasMaxLength(16);

                entity.Property(e => e.LastName).HasMaxLength(16);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNum)
                    .HasName("PK__Customer__E547399B35021D89");

                entity.ToTable("CustomerOrder");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_ID");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StoreLocation).HasMaxLength(168);
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderNum, e.ProductName })
                    .HasName("PK__OrderPro__489290E382B9CE72");

                entity.ToTable("OrderProduct");

                entity.Property(e => e.ProductName).HasMaxLength(30);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.OrderTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_LocationID");

                entity.HasOne(d => d.OrderNumNavigation)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Num");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.ProductName })
                    .HasName("PK__StoreInv__4A2B0D0F32E29B59");

                entity.ToTable("StoreInventory");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProductName).HasMaxLength(30);

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_LocationID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
