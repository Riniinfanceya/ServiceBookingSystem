using Servicebookingsystem.core.Entities;
using Servicebookingsystem.infrastructure;
using Servicebookingsystem.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepo;

        public CustomerService(IRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync() =>
            await _customerRepo.GetAllAsync();

        public async Task<Customer?> GetCustomerByIdAsync(int id) =>
            await _customerRepo.GetByIdAsync(id);

        public async Task AddCustomerAsync(Customer customer) =>
            await _customerRepo.AddAsync(customer);

        public async Task UpdateCustomerAsync(Customer customer) =>
            await _customerRepo.UpdateAsync(customer);

        public async Task DeleteCustomerAsync(Customer customer) =>
            await _customerRepo.DeleteAsync(customer);
    }
}
