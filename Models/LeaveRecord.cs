using System;
using System.ComponentModel.DataAnnotations;

namespace PayrollManagementAPI.Models
{
    public class LeaveRecord
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [MaxLength(50)]
        public string LeaveType { get; set; }
        

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MaxLength(200)]
        public string Reason { get; set; }
        [MaxLength(200)]

        public bool IsApproved { get; set; }
    }
}