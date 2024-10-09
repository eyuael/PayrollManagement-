using System;
using System.ComponentModel.DataAnnotations;

namespace PayrollManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
    }
}