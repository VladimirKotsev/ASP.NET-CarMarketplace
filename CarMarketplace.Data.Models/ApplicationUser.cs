namespace CarMarketplace.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.CarsOnSale = new HashSet<SaleCar>();
            this.Favorites = new HashSet<SalePostApplicationUser>();
        }

        public virtual ICollection<SaleCar> CarsOnSale { get; set; }

        public virtual ICollection<SalePostApplicationUser> Favorites { get; set; }
    }
}
