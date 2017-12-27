using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class ReservationServicesExtraFeatures
    {
        public int ExtraFeatureId { get; set; }
        public int ReservationServiceId { get; set; }

        public ExtraFeatures ExtraFeature { get; set; }
        public ReservationServices ReservationService { get; set; }
    }
}
