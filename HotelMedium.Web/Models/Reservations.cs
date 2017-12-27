using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Reservations
    {
        public Reservations()
        {
            AccessCodes = new HashSet<AccessCodes>();
            Bills = new HashSet<Bills>();
            ReservationOffers = new HashSet<ReservationOffers>();
            ReservationServices = new HashSet<ReservationServices>();
        }

        public int ReservationId { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DateReserved { get; set; }
        public int NumberOfPeople { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Clients Client { get; set; }
        public Rooms Room { get; set; }
        public ICollection<AccessCodes> AccessCodes { get; set; }
        public ICollection<Bills> Bills { get; set; }
        public ICollection<ReservationOffers> ReservationOffers { get; set; }
        public ICollection<ReservationServices> ReservationServices { get; set; }
    }
}
