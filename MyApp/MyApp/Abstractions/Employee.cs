using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Abstractions
{
    public class Employee
    {
        public string Name;

        public int Id { get; internal set; }

        public void GetDetails() 
        {
        }
    }
}
