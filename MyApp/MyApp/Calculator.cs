using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Calculator
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }


        //[Test]
        //public static void AddNumbers_ShouldReturnSum()
        //{
        //    int result = Calculator.Add(3, 3);
        //    Assert.That(result, Is.EqualTo(5));
        //}
    }

    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = _calculator.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up resources
        }
    }



}
