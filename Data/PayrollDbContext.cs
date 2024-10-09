using Microsoft.EntityFrameworkCore;

using PayrollManagementAPI.Models;

namespace PayrollManagementAPI.Data
{
    public class PayrollDbContext : DbContext
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryComponent> SalaryComponents { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<EmployeeDeduction> EmployeeDeductions { get; set; }
        public DbSet<LeaveRecord> LeaveRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add any additional configurations here
        }
    }
}