using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class ReservationOffers
    {
        public int ReservationOfferId { get; set; }
        public int ReservationId { get; set; }
        public int OfferId { get; set; }

        public Offers Offer { get; set; }
        public Reservations Reservation { get; set; }
    }
}
