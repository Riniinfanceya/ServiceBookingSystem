using Servicebookingsystem.core.Entities;
using Servicebookingsystem.infrastructure;
using Servicebookingsystem.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Admin> _adminRepo;

        public AdminService(IRepository<Admin> adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<IEnumerable<Admin>> GetAdminsAsync() =>
            await _adminRepo.GetAllAsync();

        public async Task<Admin?> GetAdminByIdAsync(int id) =>
            await _adminRepo.GetByIdAsync(id);

        public async Task AddAdminAsync(Admin admin) =>
            await _adminRepo.AddAsync(admin);

        public async Task UpdateAdminAsync(Admin admin) =>
            await _adminRepo.UpdateAsync(admin);

        public async Task DeleteAdminAsync(Admin admin) =>
            await _adminRepo.DeleteAsync(admin);
    }
}
