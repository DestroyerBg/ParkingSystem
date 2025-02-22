using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Data.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CarMake { get; set; } = null!;

        [Required]
        public string PlateNumber { get; set; } = null!;
    }
}
