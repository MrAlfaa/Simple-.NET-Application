using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurchaseRequestApp.Data;
using PurchaseRequestApp.Repositories;
using PurchaseRequestApp.Services;
using PurchaseRequestApp.Models;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IPurchaseRequestRepository, PurchaseRequestRepository>();
builder.Services.AddScoped<IPurchaseRequestService, PurchaseRequestService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();