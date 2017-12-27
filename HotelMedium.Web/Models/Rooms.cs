using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }

        public RoomTypes RoomType { get; set; }
        public ICollection<Reservations> Reservations { get; set; }
    }
}
