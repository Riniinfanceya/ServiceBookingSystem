using Moq;
using Servicebookingsystem.core.Entities;
using Servicebookingsystem.services.Services;
using Servicebookingsystem.infrastructure;
using Xunit;

namespace ServiceBookingSystem.Tests
{
    public class AppointmentServiceTests
    {
        [Fact]
        public async Task AddAppointment_ShouldThrow_WhenOverlaps()
        {
            var mockRepo = new Mock<IRepository<Appointment>>();
            var existing = new Appointment { StaffId = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) };

            // Fix: use Expression<Func<Appointment,bool>>
            mockRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Appointment, bool>>>()))
                    .ReturnsAsync(new List<Appointment> { existing });

            var service = new AppointmentService(mockRepo.Object);

            var newAppt = new Appointment { StaffId = 1, StartTime = DateTime.Now.AddMinutes(30), EndTime = DateTime.Now.AddHours(2) };

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.AddAppointmentAsync(newAppt));
        }


        [Fact]
        public async Task GetAppointmentById_ShouldReturnNull_WhenNotFound()
        {
            var mockRepo = new Mock<IRepository<Appointment>>();
            mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Appointment?)null);

            var service = new AppointmentService(mockRepo.Object);
            var result = await service.GetAppointmentByIdAsync(99);

            Assert.Null(result);
        }
    }
}
