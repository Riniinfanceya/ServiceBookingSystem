using Servicebookingsystem.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetStaffAsync();
        Task<Staff?> GetStaffByIdAsync(int id);
        Task AddStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(Staff staff);
    }
}
