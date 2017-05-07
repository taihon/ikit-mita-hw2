using FluentAssertions;
using LadaSedan.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadaSedan.Tests
{
    [TestClass]
    public class CarPassportTests
    {
        [TestMethod]
        public void CarPassportSetsCarProperlyOnCreation()
        {
            var car = new Car("Ferrari", 'Z');
            var cpassport = new CarPassport(car);
            cpassport.Car.Should().Be(car, "CarPassport should set Car property via constructor");
        }
    }
}
