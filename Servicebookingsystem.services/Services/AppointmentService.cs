using Servicebookingsystem.core.Entities;
using Servicebookingsystem.infrastructure;
using Servicebookingsystem.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepo;

        public AppointmentService(IRepository<Appointment> appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync() =>
            await _appointmentRepo.GetAllAsync();

        public async Task<Appointment?> GetAppointmentByIdAsync(int id) =>
            await _appointmentRepo.GetByIdAsync(id);

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            // Business rule: prevent overlapping appointments
            var overlaps = await _appointmentRepo.FindAsync(a =>
                a.StaffId == appointment.StaffId &&
                a.StartTime < appointment.EndTime &&
                appointment.StartTime < a.EndTime);

            if (overlaps.Any())
                throw new InvalidOperationException("Appointment overlaps with existing booking.");

            await _appointmentRepo.AddAsync(appointment);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment) =>
            await _appointmentRepo.UpdateAsync(appointment);

        public async Task DeleteAppointmentAsync(Appointment appointment) =>
            await _appointmentRepo.DeleteAsync(appointment);
    }
}
