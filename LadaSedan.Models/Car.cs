using System;
using System.Collections.Generic;
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
            CarPassport = new CarPassport();
        }

        public readonly char Category;
        public readonly string Model;

        public readonly CarPassport CarPassport;

        public object Color { get; set; }
    }
}
