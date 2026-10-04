using System.ComponentModel.DataAnnotations;
using Demo1.Models;

namespace Demo1.DTOs.CustomerDTOs
{
    public class CustomerProfileDTO
    {
        public string Adress { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int customerId {  get; set; }
        public String CustomerName {  get; set; }
    }
}
