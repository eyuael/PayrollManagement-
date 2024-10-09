using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollManagementAPI.Data;
using PayrollManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PayrollManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollReportController : ControllerBase
    {
        private readonly PayrollDbContext _context;

        public PayrollReportController(PayrollDbContext context)
        {
            _context = context;
        }

        [HttpGet("monthly")]
        public async Task<ActionResult<IEnumerable<MonthlyPayrollReport>>> GetMonthlyPayrollReport(int year, int month)
        {
            var report = await _context.Employees
                .Select(e => new MonthlyPayrollReport
                {
                    EmployeeId = e.Id,
                    EmployeeName = $"{e.FirstName} {e.LastName}",
                    //GrossSalary = e.SalaryComponents.Sum(sc => sc.Amount),
                    //TotalDeductions = e.EmployeeDeductions.Sum(ed => ed.Amount),
                    //NetSalary = e.SalaryComponents.Sum(sc => sc.Amount) - e.EmployeeDeductions.Sum(ed => ed.Amount)
                })
                .ToListAsync();

            return report;
        }
    }

    public class MonthlyPayrollReport
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetSalary { get; set; }
    }
}
