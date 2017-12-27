using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Events
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int EventHallId { get; set; }
        public decimal Amount { get; set; }
        public int EventTypeId { get; set; }

        public EventHalls EventHall { get; set; }
        public EventTypes EventType { get; set; }
    }
}
