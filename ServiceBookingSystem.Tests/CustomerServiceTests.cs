using Moq;
using Servicebookingsystem.core.Entities;
using Servicebookingsystem.services.Services;
using Servicebookingsystem.infrastructure;
using Xunit;
namespace ServiceBookingSystem.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task GetCustomers_ShouldReturnList()
        {
            var mockRepo = new Mock<IRepository<Customer>>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Alice", Email = "alice@test.com" }
        });

            var service = new CustomerService(mockRepo.Object);
            var result = await service.GetCustomersAsync();

            Assert.Single(result);
            Assert.Equal("Alice", result.First().Name);
        }
    }
}