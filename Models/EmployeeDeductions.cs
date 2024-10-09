using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PayrollManagementAPI.Models
{
    public class EmployeeDeduction
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        [MaxLength(100)]
        public int EmployeeId { get; set; }
        [MaxLength(100)]
        public Employee Employee { get; set; }
    }
}