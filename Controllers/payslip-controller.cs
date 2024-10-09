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
    public class PayslipController : ControllerBase
    {
        private readonly PayrollDbContext _context;

        public PayslipController(PayrollDbContext context)
        {
            _context = context;
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Payslip>> GeneratePayslip(int employeeId, int year, int month)
        {
            var employee = await _context.Employees
                .Include(e => e.SalaryComponents)
                .Include(e => e.EmployeeDeductions)
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var payslip = new Payslip
            {
                EmployeeId = employee.Id,
                EmployeeName = $"{employee.FirstName} {employee.LastName}",
                Year = year,
                Month = month,
                GrossSalary = employee.SalaryComponents.Sum(sc => sc.Amount),
                Deductions = employee.EmployeeDeductions.Select(ed => new DeductionItem
                {
                    Name = ed.Name,
                    Amount = ed.Amount
                }).ToList(),
                NetSalary = employee.SalaryComponents.Sum(sc => sc.Amount) - employee.EmployeeDeductions.Sum(ed => ed.Amount)
            };

            return payslip;
        }
    }

    public class Payslip
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal GrossSalary { get; set; }
        public List<DeductionItem> Deductions { get; set; }
        public decimal NetSalary { get; set; }
    }

    public class DeductionItem
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
