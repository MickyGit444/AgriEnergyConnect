using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Add session support
builder.Services.AddSession();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<AgriConnectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Build the app
var app = builder.Build();

// Use static files (e.g. CSS, JS)
app.UseStaticFiles();

// Use session (must come before routing)
app.UseSession();

// Enable routing
app.UseRouting();

// Map the default route
app.MapDefaultControllerRoute();

// Run the app
app.Run();
