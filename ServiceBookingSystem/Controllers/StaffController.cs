using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicebookingsystem.core.Entities;
using Servicebookingsystem.services.Interfaces;

namespace ServiceBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff() =>
            Ok(await _staffService.GetStaffAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);
            if (staff == null) return NotFound();
            return Ok(staff);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateStaff(Staff staff)
        {
            await _staffService.AddStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStaff(int id, Staff staff)
        {
            if (id != staff.StaffId) return BadRequest();
            await _staffService.UpdateStaffAsync(staff);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);
            if (staff == null) return NotFound();
            await _staffService.DeleteStaffAsync(staff);
            return NoContent();
        }
    }
}

