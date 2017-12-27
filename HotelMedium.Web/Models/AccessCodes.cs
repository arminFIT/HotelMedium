using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class AccessCodes
    {
        public string AccessCodeId { get; set; }
        public int ReservationId { get; set; }

        public Reservations Reservation { get; set; }
    }
}
