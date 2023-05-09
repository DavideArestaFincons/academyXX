using ConsoleApp2.BookModel.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.BookModel.Dto
{
    public class DtoBookPerson
    {

        public string IdPerson { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<DtoBook> Books { get; set; }

        public List<string> FF { get; set; }
        public void OnRun()
        {
            Dictionary<int, DtoBook> dic = new Dictionary<int, DtoBook>();

            dic.Add(1, new DtoBook());
            dic.Add(2, new DtoBook());

            var res = IdPerson.Prefix("PF");
        }
    }
}
