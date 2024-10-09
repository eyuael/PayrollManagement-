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
    public class LeaveController : ControllerBase
    {
        private readonly PayrollDbContext _context;

        public LeaveController(PayrollDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRecord>>> GetLeaveRecords()
        {
            return await _context.LeaveRecords.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<LeaveRecord>> CreateLeaveRecord(LeaveRecord leaveRecord)
        {
            _context.LeaveRecords.Add(leaveRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeaveRecord), new { id = leaveRecord.Id }, leaveRecord);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRecord>> GetLeaveRecord(int id)
        {
            var leaveRecord = await _context.LeaveRecords.FindAsync(id);

            if (leaveRecord == null)
            {
                return NotFound();
            }

            return leaveRecord;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveRecord(int id, LeaveRecord leaveRecord)
        {
            if (id != leaveRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(leaveRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool LeaveRecordExists(int id)
        {
            return _context.LeaveRecords.Any(e => e.Id == id);
        }
    }
}
