using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.core.Entities
{
    public class Service : BaseEntity
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public decimal Price { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }

}
