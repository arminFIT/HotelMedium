using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class ExtraFeatures
    {
        public ExtraFeatures()
        {
            ReservationServicesExtraFeatures = new HashSet<ReservationServicesExtraFeatures>();
            ServicesExtraFeatures = new HashSet<ServicesExtraFeatures>();
        }

        public int ExtraFeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ReservationServicesExtraFeatures> ReservationServicesExtraFeatures { get; set; }
        public ICollection<ServicesExtraFeatures> ServicesExtraFeatures { get; set; }
    }
}
