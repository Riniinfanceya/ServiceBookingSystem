using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.core.Entities
{
    public class Staff : BaseEntity
    {
        public int StaffId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;

        public ICollection<Appointment>? Appointments { get; set; }
    }

}
