using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Bills = new HashSet<Bills>();
            Salaries = new HashSet<Salaries>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] ProfilePictureThumb { get; set; }

        public ICollection<Bills> Bills { get; set; }
        public ICollection<Salaries> Salaries { get; set; }
    }
}
