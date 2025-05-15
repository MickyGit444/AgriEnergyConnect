using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// this is to add MVC services
    builder.Services.AddControllersWithViews();

// this is to add session support
builder.Services.AddSession();

// this is to configure the EF Core with SQL Server
builder.Services.AddDbContext<AgriConnectDbContext>(options =>
    options.UseInMemoryDatabase("AgriConnectMemoryDb"));

// this is to uild the app
    var app = builder.Build();

// this is to use static files 
    app.UseStaticFiles();

// this is to use session (must come before routing)
 app.UseSession();

// this is to enable routing
        app.UseRouting();

// this is to map the default route
app.MapDefaultControllerRoute();


// this is to run the app
app.Run();
