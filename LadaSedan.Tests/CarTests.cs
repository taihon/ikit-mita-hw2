using FluentAssertions;
using LadaSedan.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LadaSedan.Tests
{
    [TestClass]
    public class CarTests
    {
        Car car;
        [TestInitialize]
        public void TestInitialize()
        {
            car = new Car(model: "Volga", category: 'B');
        }
        [TestMethod]
        public void CarConstructorSetsPropertiesCorrectly()
        {
            car.Model.Should().Be("Volga");
            car.Category.Should().Be('B');
        }
        [TestMethod]
        public void CarsPassportCreatedOnConstruction()
        {
            car.CarPassport.Should().NotBeNull("CarPassport should be created on Cars creation");
        }
        [TestMethod]
        public void CarsDefaultColorIsBlue()
        {
            //car.Color.Should().Be(System.Drawing.Color)
        }
    }
}
