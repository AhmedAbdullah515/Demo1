using System.ComponentModel.DataAnnotations;

namespace Demo1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public List<Vehicle> Vehicles { get; set; }= new List<Vehicle>();

    }
}
