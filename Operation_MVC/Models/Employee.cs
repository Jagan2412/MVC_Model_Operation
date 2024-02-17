using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation_MVC.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}