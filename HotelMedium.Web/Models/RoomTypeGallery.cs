using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class RoomTypeGallery
    {
        public int RoomTypeGalleryId { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RoomTypeImage { get; set; }

        public RoomTypes RoomType { get; set; }
    }
}
