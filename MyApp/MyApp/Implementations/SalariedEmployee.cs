using MyApp.Abstractions;
using MyApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Implementations
{
    public class SalariedEmployee : Employee, IPayable
    {
        public decimal AnualSalary { get; set; }

        public SalariedEmployee(string name, decimal anualSalary) 
        {
            this.AnualSalary = anualSalary;
            this.Name = name;
        }

        public void Pay()
        {
            Console.WriteLine($"Employee {Name} paid: {AnualSalary / 12} ");
        }

        //public override void GetDetails()
        //{
        //    Console.WriteLine($"Worker with name: {Name} " +
        //        $"is paid {AnualSalary / 12} for the month");
        //}
    }
}
