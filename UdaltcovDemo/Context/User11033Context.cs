using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UdaltcovDemo.Models;

namespace UdaltcovDemo.Context;

public partial class User11033Context : DbContext
{
    public User11033Context()
    {
    }

    public User11033Context(DbContextOptions<User11033Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ConstructionMaterial> ConstructionMaterials { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<PickUpPoint> PickUpPoints { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159;Database=user11033;Username=user11033;password=38174");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConstructionMaterial>(entity =>
        {
            entity.HasKey(e => e.ConstructionMaterials).HasName("construction_materials_pk");

            entity.ToTable("construction_materials");

            entity.Property(e => e.ConstructionMaterials)
                .UseIdentityAlwaysColumn()
                .HasColumnName("Construction_Materials");
            entity.Property(e => e.Article).HasMaxLength(10);
            entity.Property(e => e.CurrentDiscount).HasColumnName("Current_Discount");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.MaximumPossibleDiscountSize).HasColumnName("Maximum_Possible_Discount_Size");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Picture).HasMaxLength(100);
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.UnitOfMeasurement)
                .HasMaxLength(3)
                .HasColumnName("Unit_of_measurement");

            entity.HasOne(d => d.MmanufacturerNavigation).WithMany(p => p.ConstructionMaterials)
                .HasForeignKey(d => d.Mmanufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("construction_materials_manufacturer_fk");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ConstructionMaterials)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("construction_materials_product_category_fk");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.ConstructionMaterials)
                .HasForeignKey(d => d.Supplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("construction_materials_supplier_fk");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("manufacturer_pk");

            entity.ToTable("manufacturer");

            entity.Property(e => e.ManufacturerId)
                .ValueGeneratedNever()
                .HasColumnName("manufacturer_id");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNumber).HasName("order_pk");

            entity.ToTable("Order");

            entity.Property(e => e.OrderNumber)
                .UseIdentityAlwaysColumn()
                .HasColumnName("Order_Number");
            entity.Property(e => e.CodeDivision).HasColumnName("code_division");
            entity.Property(e => e.ConstructionMaterialsId).HasColumnName("construction_materials_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OrderCode).HasColumnName("Order_Code");
            entity.Property(e => e.OrderDataDostavka).HasColumnName("Order_Data_Dostavka");
            entity.Property(e => e.OrderDataZakaz).HasColumnName("Order_Data_Zakaz");
            entity.Property(e => e.OrderSostav)
                .HasMaxLength(1000)
                .HasColumnName("Order_Sostav");
            entity.Property(e => e.OrderStatus).HasColumnName("Order_Status");
            entity.Property(e => e.Patronical).HasMaxLength(50);
            entity.Property(e => e.PickUpPoint).HasColumnName("Pick_up_Point");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CodeDivisionNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CodeDivision)
                .HasConstraintName("order_pick_up_point_fk");

            entity.HasOne(d => d.ConstructionMaterials).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ConstructionMaterialsId)
                .HasConstraintName("order_construction_materials_fk");

            entity.HasOne(d => d.OrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_order_status_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("order_user_fk");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("order_status_pk");

            entity.ToTable("order_status");

            entity.Property(e => e.OrderStatusId)
                .ValueGeneratedNever()
                .HasColumnName("order_status_id");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<PickUpPoint>(entity =>
        {
            entity.HasKey(e => e.CodeDivision).HasName("pick_up_point_pk");

            entity.ToTable("Pick_up_point");

            entity.Property(e => e.CodeDivision)
                .ValueGeneratedNever()
                .HasColumnName("Code_Division");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.HomeNumber).HasColumnName("Home_Number");
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("product_category_pk");

            entity.ToTable("product_category");

            entity.Property(e => e.ProductCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("product_category_id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pk");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("Role_ID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("supplier_pk");

            entity.ToTable("supplier");

            entity.Property(e => e.SupplierId)
                .ValueGeneratedNever()
                .HasColumnName("supplier_id");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("User_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronical).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnName("Role_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
