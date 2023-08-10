namespace CarMarketplace.Web.ViewModels.Common
{
    using System.ComponentModel.DataAnnotations;
    using CarMarketplace.Services.Mapping.Contracts;
    using Data.Models;

    public class ColorViewModel : IMapFrom<Color>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}