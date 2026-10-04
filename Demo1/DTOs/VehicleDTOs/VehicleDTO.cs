using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs.VehicleDTOs
{
    public class VehicleDTO
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
        public string CustomerName { get; set; }
    }
}
