namespace CarMarketplace.Web.ViewModels.Catalog
{
    using System.ComponentModel.DataAnnotations;

    public class ColorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}