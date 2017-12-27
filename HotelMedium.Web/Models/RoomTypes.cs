using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class RoomTypes
    {
        public RoomTypes()
        {
            RoomTypeGallery = new HashSet<RoomTypeGallery>();
            Rooms = new HashSet<Rooms>();
        }

        public int RoomTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }

        public ICollection<RoomTypeGallery> RoomTypeGallery { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
    }
}
