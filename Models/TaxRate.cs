using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PayrollManagementAPI.Models
{
    public class TaxRate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        [Precision(18, 2)]
        public decimal Rate { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}