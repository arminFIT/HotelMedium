using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class ReservationServices
    {
        public ReservationServices()
        {
            ReservationServicesExtraFeatures = new HashSet<ReservationServicesExtraFeatures>();
        }

        public int ReservationServiceId { get; set; }
        public int ServiceId { get; set; }
        public int ReservationId { get; set; }
        public DateTime DateReserved { get; set; }
        public bool IsDeleted { get; set; }

        public Reservations Reservation { get; set; }
        public Services Service { get; set; }
        public ICollection<ReservationServicesExtraFeatures> ReservationServicesExtraFeatures { get; set; }
    }
}
