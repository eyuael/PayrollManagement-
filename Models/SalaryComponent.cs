using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PayrollManagementAPI.Models
{
    public class SalaryComponent
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        [MaxLength(100)]
        public bool IsTaxable { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}