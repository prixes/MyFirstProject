using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }  = string.Empty;
        public string LastName { get; set; }
        public string Title { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

    }
}
