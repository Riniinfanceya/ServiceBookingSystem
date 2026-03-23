using Servicebookingsystem.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service?> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(Service service);
    }
}
