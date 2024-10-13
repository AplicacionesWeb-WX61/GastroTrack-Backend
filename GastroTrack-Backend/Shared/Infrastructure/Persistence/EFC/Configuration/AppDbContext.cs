using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuración de la entidad User
            builder.Entity<User>(user =>
            {
                user.HasKey(u => u.UserId);
                user.Property(u => u.UserId).IsRequired().ValueGeneratedOnAdd();
                user.Property(u => u.Email).IsRequired();
                user.Property(u => u.Password).IsRequired();
                user.Property(u => u.Company).IsRequired(false);
                user.Property(u => u.FirstName).IsRequired();
                user.Property(u => u.LastName).IsRequired();
            });
            
            // Configuración de la entidad Tasks
            builder.Entity<Tasks>(tasks =>
            {
                tasks.HasKey(t => t.TaskId);
                tasks.Property(t => t.TaskId).IsRequired().ValueGeneratedOnAdd();
                tasks.Property(t => t.TaskName).IsRequired();
                tasks.Property(t => t.TaskDescription).IsRequired();
                tasks.Property(t => t.TaskDate).IsRequired();
            });
            

            // Configuración de la entidad Product
            builder.Entity<Product>(product =>
            {
                product.HasKey(p => p.ProductId);
                product.Property(p => p.ProductId).IsRequired().ValueGeneratedOnAdd();
                product.Property(p => p.CategoryId).HasConversion<int>(); // Conversión de CategoryId
            });

            // Configuración de la entidad Role
            builder.Entity<Role>(role =>
            {
                role.HasKey(r => r.RoleId);  // Clave primaria
                role.Property(r => r.RoleId).IsRequired().ValueGeneratedOnAdd();
                role.Property(r => r.RoleName).IsRequired();  // Nombre del rol
            });

            // Configuración de la entidad Transaction
            builder.Entity<Transaction>(transaction =>
            {
                transaction.HasKey(t => t.TransactionId);
                transaction.Property(t => t.TransactionId).IsRequired().ValueGeneratedOnAdd();
                transaction.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);
                transaction.HasOne(t => t.Product).WithMany(p => p.Transactions).HasForeignKey(t => t.ProductId);
            });

            // Configuración de la entidad Inventory
            builder.Entity<Inventory>(inventory =>
            {
                inventory.HasKey(i => i.InventoryId);
                inventory.Property(i => i.InventoryId).IsRequired().ValueGeneratedOnAdd();
                inventory.HasOne(i => i.Product).WithMany(p => p.Inventories).HasForeignKey(i => i.ProductId);
            });

            // Configuración de la entidad Supplier
            builder.Entity<Supplier>(supplier =>
            {
                supplier.HasKey(s => s.SupplierId);
                supplier.Property(s => s.SupplierId).IsRequired().ValueGeneratedOnAdd();
                supplier.Property(s => s.RestaunrantName).IsRequired().ValueGeneratedOnAdd();
                supplier.Property(s => s.ContactEmail).IsRequired().ValueGeneratedOnAdd();
                supplier.Property(s => s.Phone).IsRequired().ValueGeneratedOnAdd();
                supplier.Property(s => s.SupplierPhoto).IsRequired().ValueGeneratedOnAdd();
            });

            // Configuración de la entidad Membrers
            builder.Entity<Membrers>(members =>
            {
                members.HasKey(m => m.MembersId);
                members.Property(m => m.MembersId).IsRequired().ValueGeneratedOnAdd();
                members.Property(m => m.MemberName).IsRequired();
                members.Property(m => m.Description).IsRequired(false);
                members.Property(m => m.Photo).IsRequired(false);  // Foto del miembro

                // Relación con Role
                members.HasOne(m => m.Role)
                       .WithMany(r => r.Membrers)
                       .HasForeignKey(m => m.RoleId);  // Foreign key hacia Role
            });

            // Configuración de la entidad Profile
            builder.Entity<Profile>(profile =>
            {
                profile.HasKey(p => p.ProfileId);
                profile.Property(p => p.ProfileId).IsRequired().ValueGeneratedOnAdd();
            });
            
            
            // Configuración de la entidad Notificaiones
            builder.Entity<Notification>(notification =>
            {
                notification.HasKey(n => n.NotificationId);
                notification.Property(n => n.NotificationId).IsRequired().ValueGeneratedOnAdd();
                notification.Property(n => n.NotificationName).IsRequired();
                notification.Property(n => n.NotificationDescription).IsRequired();
            });
            
            // Configuración de la entidad Report
            builder.Entity<Report>(report =>
            {
                report.HasKey(r => r.ReportId);
                report.Property(r => r.ReportId).IsRequired().ValueGeneratedOnAdd();
                report.Property(r => r.ReportName).IsRequired();
                report.Property(r => r.ReportDescription).IsRequired();
                report.Property(r => r.ReportDate).IsRequired();
            });

            

            // Aplicar convención SnakeCase para los nombres de tablas
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
}