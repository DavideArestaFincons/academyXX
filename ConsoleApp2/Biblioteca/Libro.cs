using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ConsoleApp2.Biblioteca
{
    public class Libro
    {
        public Libro(string title, BookState bookState)
        {
            Title = title;
            State = bookState;
        }

        public Libro(string title, BookState bookState, string customer, int recensioni) :
            this(title, bookState)
        {
            Customer = customer;
            NumRecensioni = recensioni;
        }

        public String Title { get; set; }

        public string Customer { get; set; }

        public BookState State { get; set; }

        public int NumRecensioni { get; set; }

    }

    public enum BookState
    { 
        Available = 0,
        NotAvailable = 1
    }
}
