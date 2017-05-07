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
        public Car(string model, char category)
        {
            Model = model;
            Category = category;
            CarPassport = new CarPassport(this);
            Color = Color.Blue;
        }

        public readonly char Category;
        public readonly string Model;

        public readonly CarPassport CarPassport;

        public Color Color { get; set; }
        public string CarNumber { get; private set; }

        public void ChangeOwner(Driver driver, string v)
        {
            CarNumber = v;
            CarPassport.Owner = driver;
            CarPassport.Owner.OwnCar(this);
        }
    }
}
