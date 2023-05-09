using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Biblioteca
{
    public class ChangeBookStatusEventArgs
    {
        public string Title { get; set; }

        public BookState BookState { get; set; }
    }
}
