namespace CarMarketplace.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.CarsOnSale = new HashSet<Car>();
        }

        public virtual ICollection<Car> CarsOnSale { get; set; }
    }
}
