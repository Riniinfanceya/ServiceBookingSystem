using Servicebookingsystem.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAdminsAsync();
        Task<Admin?> GetAdminByIdAsync(int id);
        Task AddAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
        Task DeleteAdminAsync(Admin admin);
    }
}
