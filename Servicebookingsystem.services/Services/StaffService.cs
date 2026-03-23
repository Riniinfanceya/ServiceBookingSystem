using Servicebookingsystem.core.Entities;
using Servicebookingsystem.infrastructure;
using Servicebookingsystem.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _staffRepo;

        public StaffService(IRepository<Staff> staffRepo)
        {
            _staffRepo = staffRepo;
        }

        public async Task<IEnumerable<Staff>> GetStaffAsync() =>
            await _staffRepo.GetAllAsync();

        public async Task<Staff?> GetStaffByIdAsync(int id) =>
            await _staffRepo.GetByIdAsync(id);

        public async Task AddStaffAsync(Staff staff) =>
            await _staffRepo.AddAsync(staff);

        public async Task UpdateStaffAsync(Staff staff) =>
            await _staffRepo.UpdateAsync(staff);

        public async Task DeleteStaffAsync(Staff staff) =>
            await _staffRepo.DeleteAsync(staff);
    }
}
