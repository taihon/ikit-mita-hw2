using System;

namespace LadaSedan.Models
{
    public class Driver
    {
        public readonly object Name;
        public readonly DateTime LicenceDate;

        public Driver(string name, DateTime licenseDate)
        {
            this.Name = name;
            this.LicenceDate = licenseDate;
        }

        public object Experience { get {
                return (new DateTime(1, 1, 1) 
                    + DateTime.Now.Subtract(LicenceDate)).Year - 1;
            } }
    }
}
