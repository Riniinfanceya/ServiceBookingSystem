using Servicebookingsystem.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Appointment appointment);
    }
}
