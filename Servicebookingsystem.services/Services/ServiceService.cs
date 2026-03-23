using Servicebookingsystem.core.Entities;
using Servicebookingsystem.infrastructure;
using Servicebookingsystem.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<Service> _serviceRepo;

        public ServiceService(IRepository<Service> serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync() =>
            await _serviceRepo.GetAllAsync();

        public async Task<Service?> GetServiceByIdAsync(int id) =>
            await _serviceRepo.GetByIdAsync(id);

        public async Task AddServiceAsync(Service service) =>
            await _serviceRepo.AddAsync(service);

        public async Task UpdateServiceAsync(Service service) =>
            await _serviceRepo.UpdateAsync(service);

        public async Task DeleteServiceAsync(Service service) =>
            await _serviceRepo.DeleteAsync(service);
    }
}
