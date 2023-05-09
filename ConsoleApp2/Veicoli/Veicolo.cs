using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public abstract class Veicolo
    {
        public string Colore { get; set; }

        public string Name { get; set; }
        
        public int  Speed { get; set; }

        public abstract VehicleType Type { get; }

        public virtual void Accellerate()
        {
            Speed += 5;
        }

    }

    public enum VehicleType
    {
        Car = 0,
        Bike = 1,
        Board = 2,
        Moto = 3,
        Bus = 4
    }
}
