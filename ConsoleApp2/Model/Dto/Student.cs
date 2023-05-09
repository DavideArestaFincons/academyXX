using ConsoleApp2.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Model.Dto
{
    public class Student: IPerson, IAge
    {
        public List<string> Students { get; set; }

        public String Name { get; private set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int Id { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public Student(string name)
        {
            Name = name;
          
            Students = new List<string>();
        }

        public void Calculate(ref int student)
        {
            student = 9;
        }
    }
}
