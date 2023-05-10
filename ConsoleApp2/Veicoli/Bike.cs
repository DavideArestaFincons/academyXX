using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Bike : Veicolo
    {
        public Bike()
        {
            HasWheels = true;
            NumWheels = 2;
        }
        public bool HasWheels { get; set; }  

        public int NumWheels { get; set; }

        public override VehicleType Type
        {
            get { return VehicleType.Bike; }
        }

        public override void Accellerate()
        {
            base.Accellerate();

            Speed += 3;
        }
    }
}
