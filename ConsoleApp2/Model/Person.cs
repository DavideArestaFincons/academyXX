using ConsoleApp2.Model.Dto;
using System;
using System.Diagnostics;

namespace ConsoleApp2.Model
{
    internal class Person
    {
        private string _name;

        public Person()
        {
            _name = "Pippo";
            _name.GetHashCode();
            Console.WriteLine(_name.GetHashCode());

            Rename();
            //Student student = new Student();
            //Foreign foreign = new Foreign();

            //bool? cond = false;

            //Student t = null;

            //var y = t ?? new Student("Maria");

            //t = new Student("Carlo");

            //y = t ?? new Student("Maria");

            //var t = new Foreign();

            //if(cond != null && cond.Value)
            //{
            //    Console.WriteLine("In");
            //}
            //else
            //    Console.WriteLine("Out");

            Int64 i = 3345;

            short sh = (short)i;


        }
        //errore

        public void Rename()
        {
            string _name;
            _name = "Pluto";
            Console.WriteLine(_name.GetHashCode());

        }

        public int Sum(int y, int x)
        {
            return y + x;
        }
    }
}