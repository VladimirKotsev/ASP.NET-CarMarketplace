using System.Reflection;

using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;

using CarMarketplace.Data;
using CarMarketplace.Services;
using CarMarketplace.Data.Models;
using CarMarketplace.Services.Data;
using CarMarketplace.Web.ViewModels;
using CarMarketplace.Services.Mapping;
using CarMarketplace.Services.Contracts;
using CarMarketplace.Services.Data.Contracts;
using CarMarketplace.Web.Infrastructure.Extensitions;
using AutoMapper;

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

builder.Services.AddApplicationServices(typeof(ISellerService));
builder.Services.AddApplicationServices(typeof(IMediaService));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.WebHost.UseStaticWebAssets();
builder.Services.AddControllersWithViews();


string clouldName = builder.Configuration.GetValue<string>("Cloudinary:CloudName");
string apiKey = builder.Configuration.GetValue<string>("Cloudinary:ApiKey");
string apiSecret = builder.Configuration.GetValue<string>("Cloudinary:ApiSecret");

Account cloudinaryCredentials = new Account(clouldName, apiKey, apiSecret);
Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);
builder.Services.AddSession();

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
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseEndpoints(config =>
{
    config.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    config.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    config.MapRazorPages();
});

app.Run();
