using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LadaSedan.Models;
using FluentAssertions;

namespace LadaSedan.Tests
{
    [TestClass]
    public class DriverTests
    {
        [TestMethod]
        public void DriverConstructorCorrectlySetsProperties()
        {
            var licenseDate = new DateTime(2000, 05, 05);
            var driver = new Driver("Vadim", licenseDate);
            driver.Name.Should().Be("Vadim");
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
    }
}
