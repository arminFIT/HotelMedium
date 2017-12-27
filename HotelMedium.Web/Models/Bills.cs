using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Bills
    {
        public int BillId { get; set; }
        public int ReservationId { get; set; }
        public DateTime DateIssued { get; set; }
        public bool IsDeleted { get; set; }
        public string IssuedOn { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }

        public Clients Client { get; set; }
        public Reservations Reservation { get; set; }
        public Employees User { get; set; }
    }
}
