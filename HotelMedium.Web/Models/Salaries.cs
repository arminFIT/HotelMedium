using System;
using System.Collections.Generic;

namespace HotelMedium.Web.Models
{
    public partial class Salaries
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Employees Employee { get; set; }
    }
}
