using Servicebookingsystem.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
    }
}
