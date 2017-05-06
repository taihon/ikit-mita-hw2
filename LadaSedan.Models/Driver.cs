using System;
using System.Collections.Generic;

namespace LadaSedan.Models
{
    public class Driver
    {
        public readonly string Name;
        public readonly DateTime LicenceDate;

        public Driver(string name, DateTime licenseDate)
        {
            this.Name = name;
            this.LicenceDate = licenseDate;
            this.Category = new HashSet<char>();
        }

        public int Experience { get {
                return (new DateTime(1, 1, 1) 
                    + DateTime.Now.Subtract(LicenceDate)).Year - 1;
            } }

        public HashSet<Char> Category { get; set; }
        public Car Car { get; private set; }

        public void OwnCar(Car car)
        {
            if (!Category.Contains(car.Category) && car.Category != '\0')
            {
                throw new InvalidOperationException($"Driver {Name} doesn't have category {car.Category} required by car!");
            } else { Car = car; }
        }
    }
}
