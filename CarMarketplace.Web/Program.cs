using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using CarMarketplace.Data;
using CarMarketplace.Data.Models;
using CarMarketplace.Services;
using CarMarketplace.Services.Contracts;
using System.Security.Principal;
using CloudinaryDotNet;
using CarMarketplace.Web.ViewModels;
using System.Reflection;
using CarMarketplace.Services.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarMarketplaceDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount =
        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
    options.Password.RequireLowercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
    options.Password.RequireUppercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
    options.Password.RequireNonAlphanumeric =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
    options.Password.RequiredLength =
        builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
})
.AddEntityFrameworkStores<CarMarketplaceDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ILenderService, LenderService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();



string clouldName = builder.Configuration.GetValue<string>("Cloudinary:CloudName");
string apiKey = builder.Configuration.GetValue<string>("Cloudinary:ApiKey");
string apiSecret = builder.Configuration.GetValue<string>("Cloudinary:ApiSecret");

Account cloudinaryCredentials = new Account(clouldName, apiKey, apiSecret);
Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);

builder.Services.AddSingleton(cloudinary);

var app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
app.MapRazorPages();

app.Run();
