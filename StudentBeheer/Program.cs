using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentBeheer.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentBeheerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentBeheerContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataBaseSeeder.Initialize(services);
}
app.Run();
