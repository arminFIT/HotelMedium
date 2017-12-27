using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class EventHalls
    {
        public EventHalls()
        {
            Events = new HashSet<Events>();
        }

        public int EventHallId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public ICollection<Events> Events { get; set; }
    }
}
