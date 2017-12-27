using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMedium.Web.Models.ClientViewModels
{
    public class ClientAddVM
    {

       
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CreditCardNumber { get; set; }
        public int CreditCardCsc { get; set; }
        public DateTime DateCardExpiration { get; set; }
        public string Sex { get; set; }

        public List<Countries> countries { get; set; }
        public List<Cities> cities { get; set; }

        public Countries country { get; set; }
        public Cities city { get; set; }


    }
}
