using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
