using System.ComponentModel.DataAnnotations;
using Demo1.Models;

namespace Demo1.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        [Required, MaxLength(20)]
        public string DriverLicenseNumber { get; set; }
    }
}
