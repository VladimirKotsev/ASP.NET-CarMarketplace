namespace CarMarketplace.Data
{
    using System.Reflection;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using CarMarketplace.Data.Models;

    public class CarMarketplaceDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public CarMarketplaceDbContext(DbContextOptions<CarMarketplaceDbContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarManufacturer> Manufacturers { get; set; }
        public DbSet<CarModel> Models { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SalePost> SalePosts { get; set; }
        public DbSet<RentPost> RentPosts { get; set; }
        public DbSet<Lender> Lenders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(CarMarketplaceDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}