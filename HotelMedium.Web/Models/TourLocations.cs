using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class TourLocations
    {
        public TourLocations()
        {
            Tours = new HashSet<Tours>();
        }

        public int TourLocationId { get; set; }
        public string Name { get; set; }
        public decimal Distance { get; set; }

        public ICollection<Tours> Tours { get; set; }
    }
}
