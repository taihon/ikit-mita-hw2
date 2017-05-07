using System;
using System.Collections.Generic;
using System.Text;

namespace LadaSedan.Models
{
    public class CarPassport
    {

        public CarPassport(Car car)
        {
            this.Car = car;
        }

        public Driver Owner { get; set; }
        public Car Car { get; set; }
    }
}
