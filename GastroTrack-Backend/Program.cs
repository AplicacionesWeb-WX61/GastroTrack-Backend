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
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if(connectionString == null) throw new Exception("No connection string found");
        options
            .UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        var connectionString = builder.Configuration.GetConnectionString("ProductionConnection");
        if(connectionString == null) throw new Exception("No connection string found");
        var GetFormatedString = ()=>{
            string? host = DotNetEnv.Env.GetString("MYSQL_HOST") ?? Environment.GetEnvironmentVariable("MYSQL_HOST");
            if(host == null) throw new Exception("No MYSQL_HOST found");
            string? user = DotNetEnv.Env.GetString("MYSQL_USER") ?? Environment.GetEnvironmentVariable("MYSQL_USER");
            if(user == null) throw new Exception("No MYSQL_USER found");
            string? password = DotNetEnv.Env.GetString("MYSQL_PASSWORD") ?? Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
            if(password == null) throw new Exception("No MYSQL_PASSWORD found");
            string? database = DotNetEnv.Env.GetString("MYSQL_DATABASE") ?? Environment.GetEnvironmentVariable("MYSQL_DATABASE");
            if(database == null) throw new Exception("No MYSQL_DATABASE found");
            string? port = DotNetEnv.Env.GetString("MYSQL_PORT") ?? Environment.GetEnvironmentVariable("MYSQL_PORT");
            if(port == null) throw new Exception("No MYSQL_PORT found");

            return String.Format(connectionString, host, user, password, database, port);
        };
        connectionString = GetFormatedString();
        options
            .UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    }
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
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
