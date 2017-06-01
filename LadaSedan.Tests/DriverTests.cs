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
        private Driver _driver;
        private DateTime _licenseDate;
        [TestInitialize]
        public void TestInitialize()
        {
            _licenseDate = DateTime.Now.AddYears(-10);
            _driver = new Driver("Rajesh", _licenseDate);
        }
        [TestMethod]
        public void DriverConstructorCorrectlySetsProperties()
        {
            _driver.Name.Should().Be("Rajesh");
            _driver.LicenceDate.Should().Be(_licenseDate);
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
            _driver.Category.Add(DrivingLicenseCategory.B);
            _driver.Category.Should().Contain(c => c == DrivingLicenseCategory.B);
        }

        [TestMethod]
        public void CategoryIsNotAddedWhenAlreadyPresentInCategories()
        {
            var driver = new Driver("Rajesh", DateTime.Now.AddYears(-10));
            driver.Category.Add(DrivingLicenseCategory.A);
            driver.Category.Add(DrivingLicenseCategory.A);
            driver.Category.Should().HaveCount(1, "category should be added only once");
        }
        [TestMethod]
        public void OwnCarSetsDriversCar()
        {
            var car = new Car("",DrivingLicenseCategory.B);
            _driver.Category.Add(DrivingLicenseCategory.B);
            _driver.OwnCar(car);
            _driver.Car.Should().Be(car, "OwnCar method should set driver's Car property to instance of Car passed to OwnCar function");
        }
        [TestMethod]
        public void OwnCarThrowsIfDriverDoesntHaveCategoryRequiredByCar()
        {
            var car = new Car("", DrivingLicenseCategory.B);
            Action a = () => _driver.OwnCar(car);
            a.ShouldThrow<InvalidOperationException>().WithMessage($"Driver {_driver.Name} doesn't have category {car.Category} required by car!");
        }
        [TestMethod]
        public void ExperienceCalculatesCorrectlyWhenDatesAreSlightlyAway()
        {
            var ld = new DateTime(2015,01,03);
            var now = new DateTime(2017,01,02);
            var t = (new DateTime(1, 1, 1)
                     + now.Subtract(ld)).Year - 1;
            if (now.AddYears(-t) < ld)
                t--;
            t.Should().Be(1);
        }
    }
}
