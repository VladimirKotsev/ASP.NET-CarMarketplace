namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class ProvinceEntityConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            //builder.HasData(this.GenerateProvinces());
        }

        private Province[] GenerateProvinces()
        {
            ICollection<Province> provinces = new HashSet<Province>();

            int id = 1;

            provinces.Add(new Province() { Id = id++, ProvinceName = "Blagoevgrad" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Burgas" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Dobrich" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Gabrovo" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Haskovo" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Kardzhali" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Kyustendil" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Lovech" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Montana" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Pazardzhik" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Pernik" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Pleven" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Plovdiv" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Razgrad" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Ruse" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Shumen" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Silistra" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Sliven" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Smolyan" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Sofia-City" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Sofia" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Stara Zagora" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Targovishte" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Varna" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Veliko Tarnovo" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Vidin" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Vratsa" });
            provinces.Add(new Province() { Id = id++, ProvinceName = "Yambol" });

            return provinces.ToArray();
        }
    }
}
