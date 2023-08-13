namespace CarMarketplace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidations.CarModel;

    public class CarModel
    {
        public CarModel()
        {
            this.Cars = new HashSet<SaleCar>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ManufacturerMaxLength)]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLenght)]
        public string ModelName { get; set; } = null!;
        public ICollection<SaleCar> Cars { get; set; }
    }
}
