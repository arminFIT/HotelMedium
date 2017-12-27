using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class ServicesExtraFeatures
    {
        public int ExtraFeatureId { get; set; }
        public int ServiceId { get; set; }

        public ExtraFeatures ExtraFeature { get; set; }
        public Services Service { get; set; }
    }
}
