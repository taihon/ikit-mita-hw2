using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadaSedan.Models
{
    public class Car
    {
        public Car(string model, DrivingLicenseCategory category)
        {
            Model = model;
            Category = category;
            CarPassport = new CarPassport(this);
            Color = Color.Blue;
        }

        public string Model { get; }

        public CarPassport CarPassport { get; }

        public Color Color { get; set; }
        public string CarNumber { get; private set; }

        public DrivingLicenseCategory Category { get; }

        public void ChangeOwner(Driver driver, string v)
        {
            driver.OwnCar(this);
            CarNumber = v;
            CarPassport.Owner = driver;
        }
    }
}
