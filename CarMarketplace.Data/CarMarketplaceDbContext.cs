namespace CarMarketplace.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class CarMarketplaceDbContext : IdentityDbContext
    {
        public CarMarketplaceDbContext(DbContextOptions<CarMarketplaceDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}