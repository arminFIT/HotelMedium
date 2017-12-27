using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class EventTypes
    {
        public EventTypes()
        {
            Events = new HashSet<Events>();
        }

        public int EventTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Events> Events { get; set; }
    }
}
