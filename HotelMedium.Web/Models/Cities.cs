using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Clients = new HashSet<Clients>();
        }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public Countries Country { get; set; }
        public ICollection<Clients> Clients { get; set; }
    }
}
