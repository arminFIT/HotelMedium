using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Offers
    {
        public Offers()
        {
            ReservationOffers = new HashSet<ReservationOffers>();
        }

        public int OfferId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public ICollection<ReservationOffers> ReservationOffers { get; set; }
    }
}
