using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs.VehicleDTOs
{
    public class UpdateVehicleDTO
    {
      
        [Required]
        [MinLength(1)]
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }
    }
}
