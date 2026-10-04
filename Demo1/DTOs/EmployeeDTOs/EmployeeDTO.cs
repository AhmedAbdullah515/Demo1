using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string Position { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public int saleCount {  get; set; }
    }
}
