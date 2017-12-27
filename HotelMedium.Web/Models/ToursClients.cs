using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class ToursClients
    {
        public int TourClientId { get; set; }
        public int TourId { get; set; }
        public int ClientId { get; set; }

        public Clients Client { get; set; }
        public Tours Tour { get; set; }
    }
}
