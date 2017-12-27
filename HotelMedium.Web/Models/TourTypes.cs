using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class TourTypes
    {
        public TourTypes()
        {
            Tours = new HashSet<Tours>();
        }

        public int TourTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Tours> Tours { get; set; }
    }
}
