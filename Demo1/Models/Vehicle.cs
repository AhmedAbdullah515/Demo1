using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [Required]
        [MinLength(1)]
        public decimal Price { get; set; }
        [Required]
        [MinLength(1)]
        public int Mileage1 { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(30)]
        public string? FuelType { get; set; }
        [MaxLength(30)]
        public string? Transmission { get; set; }
        [Required]
        public string Status { get; set; }
        public int Id { get; set; }
        public Category Category { get; set; }
        public Sale Sale { get; set; }

    }
}
