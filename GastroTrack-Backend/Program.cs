using chefstock_platform.InventoryManagement.Application.Internal.CommandServices;
using chefstock_platform.InventoryManagement.Application.Internal.QueryServices;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.InventoryManagement.Domain.Services;
using chefstock_platform.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;
using chefstock_platform.InventoryManagement.Interfaces.ACL;
using chefstock_platform.InventoryManagement.Interfaces.ACL.Services;
using chefstock_platform.RestaurantManagement.Application.Internal.CommandServices;
using chefstock_platform.RestaurantManagement.Application.Internal.QueryServices;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.RestaurantManagement.Infrastructure.Persistence.EFC.Repositories;
using chefstock_platform.RestaurantManagement.Interfaces.ACL;
using chefstock_platform.RestaurantManagement.Interfaces.ACL.Services;
using chefstock_platform.Shared.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using chefstock_platform.Shared.Interfaces.ASP.Configuration;
using chefstock_platform.UserManagement.Application.Internal.CommandServices;
using chefstock_platform.UserManagement.Application.Internal.QueryServices;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.UserManagement.Infrastructure.Persistence.EFC.Repositories;
using chefstock_platform.UserManagement.Interfaces.ACL;
using chefstock_platform.UserManagement.Interfaces.ACL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });
// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configure Dependency Injection
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductsContextFacade, ProductsContextFacade>();

// Supplier Dependency Injection
builder.Services.AddScoped<ISupplierCommandService, SupplierCommandService>();
builder.Services.AddScoped<ISupplierQueryService, SupplierQueryService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierContextFacade, SupplierContextFacade>();

// Restaurant and Employee Dependency Injection
builder.Services.AddScoped<IRestaurantCommandService, RestaurantCommandService>();
builder.Services.AddScoped<IRestaurantQueryService, RestaurantQueryService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantContextFacade, RestaurantContextFacade>();

builder.Services.AddScoped<IEmployeeCommandService, EmployeeCommandService>();
builder.Services.AddScoped<IEmployeeQueryService, EmployeeQueryService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeContextFacade, EmployeeContextFacade>();

// User Dependency Injection
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserContextFacade, UserContextFacade>();

// Profile Dependency Injection
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileContextFacade, ProfileContextFacade>();

// Role Dependency Injection
builder.Services.AddScoped<IRoleCommandService, RoleCommandService>();
builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleContextFacade, RoleContextFacade>();

// Transaction Dependency Injection
builder.Services.AddScoped<ITransactionCommandService, TransactionCommandService>();
builder.Services.AddScoped<ITransactionQueryService, TransactionQueryService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionContextFacade, TransactionContextFacade>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "GastroTrack_platform API",
                Version = "v1",
                Description = "GastroTrack Platform API",
                TermsOfService = new Uri("https://github.com/FoodStockOS/ChefStock-Documentation"),
                Contact = new OpenApiContact
                {
                    Name = "FoodStockOS",
                    Email = "contact@chefstock.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

var app = builder.Build();

// Verify Database Objects area Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
