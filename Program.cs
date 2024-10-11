using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using SpendSmart_Second_Web_application_.Controllers;
using SpendSmart_Second_Web_application_.Data;
using SpendSmart_Second_Web_application_.Models;
using SpendSmart_Second_Web_application_.Services;
using SpendSmart_Second_Web_application_.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SpendSmartDbContext>(x=>x.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddScoped<IDatabaseHome, HomeService>();
builder.Services.AddScoped<HomeService>();
// Після того, як змінили наслідування і додали це, робимо міграцію AddUsers і update database
builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
}
).AddEntityFrameworkStores<SpendSmartDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Authorization}/{id?}");

app.Run();
