namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            //builder.HasData(this.GenerateColors());
        }


        //This method seeds data for car colors in the database
        private Color[] GenerateColors()
        {
            var colors = new HashSet<Color>();
            int id = 1;

            colors.Add(new Color
            {
                Id = id++,
                Name = "Black"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "White"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Gray"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Red"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Blue"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Green"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Yellow"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Orange"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Brown"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Beige"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Purple"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Pink"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Gold"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Bronze"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Navy"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Teal"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Burgundy"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Charcoal"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Cream"
            });
            colors.Add(new Color
            {
                Id = id++,
                Name = "Silver"
            });
            return colors.ToArray();
        }
    }
}
