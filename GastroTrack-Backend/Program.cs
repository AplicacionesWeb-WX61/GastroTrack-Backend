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
using DotNetEnv;

Env.Load();

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
    var environment = builder.Environment.EnvironmentName;

    var connectionString = environment switch
    {
        "Development" => builder.Configuration.GetConnectionString("DefaultConnection"),
        "Production" => GetFormattedConnectionString(),
        _ => throw new Exception("Unknown environment")
    };

    if (string.IsNullOrEmpty(connectionString))
        throw new Exception("No connection string found");

    options
        .UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
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
builder.Services.AddScoped<IMembrersCommandService, MembrersCommandService>();
builder.Services.AddScoped<IMembrersQueryService, MembrersQueryService>();
builder.Services.AddScoped<IMembrersRepository, MembrersRepository>();
builder.Services.AddScoped<IMembersContextFacade, MembersContextFacade>();

// User Dependency Injection
builder.Services.AddScoped<ITaskCommandService, TaskCommandService>();
builder.Services.AddScoped<ITaskQueryService, TaskQueryService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskContextFacade, TaskContextFacade>();


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

// Notification Dependency Injection
builder.Services.AddScoped<INotificationCommandService, NotificationCommandService>();
builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationContextFacade, NotificationContextFacade>();

// Report Dependency Injection
builder.Services.AddScoped<IReportCommandService, ReportCommandService>();
builder.Services.AddScoped<IReportQueryService, ReportQueryService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportContextFacade, ReportContextFacade>();


// Transaction Dependency Injection
builder.Services.AddScoped<ITransactionCommandService, TransactionCommandService>();
builder.Services.AddScoped<ITransactionQueryService, TransactionQueryService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionContextFacade, TransactionContextFacade>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
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

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
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

// Helper method to format the connection string for production
string GetFormattedConnectionString()
{
    var connectionStringTemplate = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connectionStringTemplate))
        throw new Exception("No connection string template found");

    string? host = Env.GetString("MYSQL_HOST");
    string? user = Env.GetString("MYSQL_USER");
    string? password = Env.GetString("MYSQL_PASSWORD");
    string? database = Env.GetString("MYSQL_DATABASE");
    string? portStr = Env.GetString("MYSQL_PORT");

    if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(portStr))
        throw new Exception("Environment variables for MySQL are missing");

    if (!int.TryParse(portStr, out int port))
        throw new Exception("MYSQL_PORT should be a valid number");

    // Debug output for verification
    Console.WriteLine($"Host: {host}");
    Console.WriteLine($"User: {user}");
    Console.WriteLine($"Password: {password}");
    Console.WriteLine($"Database: {database}");
    Console.WriteLine($"Port: {port}");

    return string.Format(connectionStringTemplate, host, user, password, database, port);
}
