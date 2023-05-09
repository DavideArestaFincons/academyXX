using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Biblioteca
{
    public class ChangeReviewStatusEventArgs
    {
        public string Title { get; set; }

        public int Review { get; set; }
    }
}
