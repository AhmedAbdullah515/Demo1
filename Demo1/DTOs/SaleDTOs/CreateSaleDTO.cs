using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs.SaleDTOs
{
    public class CreateSaleDTO
    {

        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        [Required, MaxLength(30)]
        public string PaymentMethod { get; set; }
        [MaxLength(300)]
        public string? Notes
        {
            get; set;
        }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId {  get; set; }

    }
}
