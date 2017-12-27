using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Services
    {
        public Services()
        {
            ReservationServices = new HashSet<ReservationServices>();
            ServicesExtraFeatures = new HashSet<ServicesExtraFeatures>();
        }

        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ReservationServices> ReservationServices { get; set; }
        public ICollection<ServicesExtraFeatures> ServicesExtraFeatures { get; set; }
    }
}
