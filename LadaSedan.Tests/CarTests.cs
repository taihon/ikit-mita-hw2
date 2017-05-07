using FluentAssertions;
using LadaSedan.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            car.Color.Should().Be(Color.Blue, "default Car.Color should be blue");
        }
        [TestMethod]
        public void CarColorShouldBeChangeable()
        {
            car.Color = Color.Beige;
            car.Color.Should().Be(Color.Beige, "Car.Color should be changeable");
        }
        [TestMethod]
        public void CarChangeOwnerChangesCarNumber()
        {
            var driver = new Driver("Rajesh", DateTime.Today);
            driver.Category.Add('B');
            car.ChangeOwner(driver,"A001BC");
            car.CarNumber.Should().Be("A001BC", "changing car's owner should change CarNumber");
        }
        [TestMethod]
        public void CarChangeOwnerShouldChangeOwnerInPassport()
        {
            var driver = new Driver("Rajesh", DateTime.Today);
            driver.Category.Add('B');
            car.ChangeOwner(driver, "A001BC");
            car.CarPassport.Owner.Should().Be(driver, "Car.ChangeOwner should change owner in Car.CarPassport");
        }
        [TestMethod]
        public void CarChangeOwnerShouldChangeOwnersCar()
        {
            var driver = new Driver("Rajesh", DateTime.Today);
            driver.Category.Add('B');
            car.ChangeOwner(driver, "A001BC");
            car.CarPassport.Owner.Car.Should().Be(car, "Car.ChangeOwner should change owner's car in Car.CarPassport");
        }
    }
}
