namespace CarMarketplace.Data
{
    using System.Reflection;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using CarMarketplace.Data.Models;
    using System.Collections.Generic;

    public class CarMarketplaceDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public CarMarketplaceDbContext(DbContextOptions<CarMarketplaceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarManufacturer> Manufacturers { get; set; } = null!;
        public DbSet<CarModel> Models { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<SalePost> SalePosts { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;
        public DbSet<SalePostApplicationUser> SalePostApplicationUsers { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(CarMarketplaceDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}