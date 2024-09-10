using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().OwnsOne(u => u.Email);

        // Product Context
        builder.Entity<Product>().HasKey(p => p.ProductId);
        builder.Entity<Product>().Property(p => p.ProductId).IsRequired().ValueGeneratedOnAdd();
        
        // Role Context
        builder.Entity<Role>().HasKey(r => r.RoleId);
        builder.Entity<Role>().Property(r => r.RoleId).IsRequired().ValueGeneratedOnAdd();
        
        // User Context
        builder.Entity<User>().HasKey(u => u.UserId);
        builder.Entity<User>().Property(u => u.UserId).IsRequired().ValueGeneratedOnAdd();
        
        // Transaction Context
        builder.Entity<Transaction>().HasKey(t => t.TransactionId);
        builder.Entity<Transaction>().Property(t => t.TransactionId).IsRequired().ValueGeneratedOnAdd();

        // Inventory Context
        builder.Entity<Inventory>().HasKey(i => i.InventoryId); 
        builder.Entity<Inventory>().Property(i => i.InventoryId).IsRequired().ValueGeneratedOnAdd();
        
        // Supplier Context
        builder.Entity<Supplier>().HasKey(s => s.SupplierId); 
        builder.Entity<Supplier>().Property(s => s.SupplierId).IsRequired().ValueGeneratedOnAdd();
        
        // Employee Context
        builder.Entity<Employee>().HasKey(e => e.EmployeeId); 
        builder.Entity<Employee>().Property(e => e.EmployeeId).IsRequired().ValueGeneratedOnAdd();

        // Profile Context
        builder.Entity<Profile>().HasKey(p => p.ProfileId); 
        builder.Entity<Profile>().Property(p => p.ProfileId).IsRequired().ValueGeneratedOnAdd();

        // Restaurant Context
        builder.Entity<Restaurant>().HasKey(r => r.RestaurantId); 
        builder.Entity<Restaurant>().Property(r => r.RestaurantId).IsRequired().ValueGeneratedOnAdd();
        
        /*
        // Category and Supplier Relationships
        builder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithOne()
            .HasForeignKey(c => c.CategoryId);

        builder.Entity<Product>()
            .HasMany(p => p.Suppliers)
            .WithOne()
            .HasForeignKey(s => s.SupplierId);
        */
        builder.Entity<Product>()
            .Property(p => p.CategoryId)
            .HasConversion<int>();
        
        // Product Relationships
        builder.Entity<Inventory>()
            .HasOne(i => i.Product)
            .WithMany(p => p.Inventories)
            .HasForeignKey(i => i.ProductId);
        
        // User and Role Relationships
        builder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

// Transaction Relationships
        builder.Entity<Transaction>()
            .HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId);
        
        // Product and Transaction Relationships
        builder.Entity<Transaction>()
            .HasOne(t => t.Product)
            .WithMany(p => p.Transactions)
            .HasForeignKey(t => t.ProductId);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}