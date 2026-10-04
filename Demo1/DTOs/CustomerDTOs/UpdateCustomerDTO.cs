using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs.CustomerDTOs
{
    public class UpdateCustomerDTO
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        [Required, MaxLength(20)]
        public string DriverLicenseNumber { get; set; }
    }
}
