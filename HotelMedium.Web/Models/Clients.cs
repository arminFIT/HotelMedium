using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Bills = new HashSet<Bills>();
            Reservations = new HashSet<Reservations>();
            ToursClients = new HashSet<ToursClients>();
        }

        public int ClientId { get; set; }
        public int CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CreditCardNumber { get; set; }
        public int CreditCardCsc { get; set; }
        public DateTime DateCardExpiration { get; set; }
        public bool IsDeleted { get; set; }
        public string Sex { get; set; }

        public Cities City { get; set; }
        public ICollection<Bills> Bills { get; set; }
        public ICollection<Reservations> Reservations { get; set; }
        public ICollection<ToursClients> ToursClients { get; set; }
    }
}
