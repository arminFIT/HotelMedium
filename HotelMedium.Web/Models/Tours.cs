using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Tours
    {
        public Tours()
        {
            ToursClients = new HashSet<ToursClients>();
        }

        public int TourId { get; set; }
        public string Name { get; set; }
        public int TourLocationId { get; set; }
        public decimal Amount { get; set; }
        public int TourTypeId { get; set; }

        public TourLocations TourLocation { get; set; }
        public TourTypes TourType { get; set; }
        public ICollection<ToursClients> ToursClients { get; set; }
    }
}
