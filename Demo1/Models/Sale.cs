using System.ComponentModel.DataAnnotations;

namespace Demo1.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required, MinLength(1)]
        public decimal SalePrice { get; set; }
        [Required, MaxLength(30)]
        public string PaymentMethod { get; set; }
        [MaxLength(300)]
        public string? Notes { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

    }
}
