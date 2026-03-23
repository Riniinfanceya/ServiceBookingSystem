using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicebookingsystem.core.Entities;
using Servicebookingsystem.services.Interfaces;

namespace ServiceBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments() =>
            Ok(await _appointmentService.GetAppointmentsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointment(Appointment appointment)
        {
            try
            {
                await _appointmentService.AddAppointmentAsync(appointment);
                return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentId }, appointment);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId) return BadRequest();
            await _appointmentService.UpdateAppointmentAsync(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            await _appointmentService.DeleteAppointmentAsync(appointment);
            return NoContent();
        }
    }
}

