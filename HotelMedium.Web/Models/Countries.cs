using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Cities> Cities { get; set; }
    }
}
