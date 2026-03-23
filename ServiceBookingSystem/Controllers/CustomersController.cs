using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicebookingsystem.core.Entities;
using Servicebookingsystem.services.Interfaces;

namespace ServiceBookingSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers() =>
            Ok(await _customerService.GetCustomersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateCustomer(Customer customer)
        {
            await _customerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId) return BadRequest();
            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            await _customerService.DeleteCustomerAsync(customer);
            return NoContent();
        }
    }
}

