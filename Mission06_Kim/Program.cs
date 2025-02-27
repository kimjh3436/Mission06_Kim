using Microsoft.EntityFrameworkCore;
using Mission06_Kim.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllersWithViews();

// Configure database connection using SQLite
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline for different environments
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Redirect errors to the error page
    app.UseHsts(); // Enforce HTTPS in production
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles(); // Serve static files like CSS, JavaScript, and images

app.UseRouting(); // Enable request routing

app.UseAuthorization(); // Enable authentication and authorization

// Define default route mapping for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Start the application