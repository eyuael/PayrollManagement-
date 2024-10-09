using System;
using System.Collections.Generic;
using System.Linq;
using PayrollManagementAPI.Models;

namespace PayrollManagementAPI.Services
{
    public class DeductionCalculatorService
    {
        public decimal CalculateTotalDeductions(Employee employee, decimal grossSalary)
        {
            decimal totalDeductions = 0;


            // Calculate fixed deductions
            

            // Calculate percentage-based deductions (e.g., tax)
            totalDeductions += CalculateTax(grossSalary);

            return totalDeductions;
        }

        private decimal CalculateTax(decimal grossSalary)
        {
            // This is a simplified tax calculation. You should implement a more complex
            // tax calculation based on your local tax regulations.
            if (grossSalary <= 1000)
                return grossSalary * 0.1m;
            else if (grossSalary <= 5000)
                return grossSalary * 0.2m;
            else
                return grossSalary * 0.3m;
        }
    }
}
