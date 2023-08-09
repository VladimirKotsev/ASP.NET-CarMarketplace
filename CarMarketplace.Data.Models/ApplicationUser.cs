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
            this.CarsOnSale = new HashSet<Car>();
            this.Favorites = new HashSet<SalePostApplicationUsers>();
        }

        public virtual ICollection<Car> CarsOnSale { get; set; }

        public virtual ICollection<SalePostApplicationUsers> Favorites { get; set; }
    }
}
