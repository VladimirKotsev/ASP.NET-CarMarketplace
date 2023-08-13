namespace CarMarketplace.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.HasData(GenerateData());
        }

        //This method seeds all data for categories in the database
        private static Category[] GenerateData()
        {
            ICollection<Category> categories = new HashSet<Category>();

            int id = 1;

            categories.Add(new Category
            {
                Id = id++,
                Name = "Sedan"
            });

            categories.Add(new Category
            {
                Id = id++,
                Name = "Hatchback"
            });

            categories.Add(new Category
            {
                Id = id++,
                Name = "SUV"
            });

            categories.Add(new Category
            {
                Id = id++,
                Name = "Crossover"
            });

            categories.Add(new Category
            {
                Id = id++,
                Name = "Coupe"
            });

            categories.Add(new Category
            {
                Id = id++,
                Name = "Convertible"
            });

            categories.Add(new Category
            {
                Id = id++,
                Name = "Wagon/Estate"
            });

            categories.Add(new Category
            {
                Id = id++,
                Name = "Minivan"
            });

            return categories.ToArray();
        }
    }
}
