using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LadaSedan.Models;
using FluentAssertions;
using System.Collections.Generic;

namespace LadaSedan.Tests
{
    [TestClass]
    public class DriverTests
    {
        private Driver driver;
        private DateTime licenseDate;
        [TestInitialize]
        public void TestInitialize()
        {
            licenseDate = DateTime.Now.AddYears(-10);
            driver = new Driver("Rajesh", licenseDate);
        }
        [TestMethod]
        public void DriverConstructorCorrectlySetsProperties()
        {
            driver.Name.Should().Be("Rajesh");
            driver.LicenceDate.Should().Be(licenseDate);
        }
        [TestMethod]
        public void ExperienceShouldBe2WhenLicenceDateIs2YearsAgo()
        {
            var licenseDate = DateTime.Now.AddYears(-2);
            var driver = new Driver("Vasily", licenseDate);
            driver.Experience.Should().Be(2);
        }
        [TestMethod]
        public void ExperienceShouldBe3WhenLicenceDateIs3YearsAgo()
        {
            var licenseDate = DateTime.Now.AddYears(-3);
            var driver = new Driver("Vasily", licenseDate);
            driver.Experience.Should().Be(3);
        }
        [TestMethod]
        public void CategoryIsAddable()
        {
            driver.Category.Add('B');
            driver.Category.Should().Contain(c => c == 'B');
        }

        [TestMethod]
        public void CategoryIsNotAddedWhenAlreadyPresentInCategories()
        {
            var driver = new Driver("Rajesh", DateTime.Now.AddYears(-10));
            driver.Category.Add('A');
            driver.Category.Should().HaveCount(1, "category should be added only once");
        }
        [TestMethod]
        public void OwnCarSetsDriversCar()
        {
            var car = new Car();
            driver.OwnCar(car);
            driver.Car.Should().Be(car, "OwnCar method should set driver's Car property to instance of Car passed to OwnCar function");
        }
        [TestMethod]
        public void OwnCarThrowsIfDriverDoesntHaveCategoryRequiredByCar()
        {
            var car = new Car()
            {
                Category = 'B'
            };
            Action a = () => driver.OwnCar(car);
            a.ShouldThrow<InvalidOperationException>().WithMessage($"Driver {driver.Name} doesn't have category {car.Category} required by car!");
        }
    }
}
