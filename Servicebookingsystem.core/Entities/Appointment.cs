using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.core.Entities
{
    public class Appointment : BaseEntity
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int ServiceId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = "Booked";

        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
        public Service? Service { get; set; }
    }

}
