using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Data.Models
{
    public class Car
    {
        [Required]
        [Key]
        public string CarMake { get; set; } = null!;

        [Required]
        public string PlateNumber { get; set; } = null!;
    }
}
