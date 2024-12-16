using MyApp.Abstractions;
using MyApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Implementations
{
    public class HourlyEmployee : Employee, IPayable
    {
        public decimal MoneyPerHour;
        public decimal WorkedHours;
        public HourlyEmployee(string name, decimal moneyPerHour, decimal workedHours)
        {
            this.MoneyPerHour = moneyPerHour;
            this.WorkedHours = workedHours;
            this.Name = name;
        }

        //public override void GetDetails()
        //{
        //    Console.WriteLine($"Worker with name: {Name} " +
        //        $"is paid {MoneyPerHour * WorkedHours} for the month");
        //}

        public void Pay()
        {
            Console.WriteLine($"Paid {MoneyPerHour * WorkedHours} to employee {Name}");
        }
    }
}
