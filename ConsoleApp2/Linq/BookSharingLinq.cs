using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp2.Biblioteca;

namespace ConsoleApp2.Linq
{
    public class BookSharingLinq
    {
        public List<Libro> Books { get; private set; }

        public BookSharingLinq()
        {
            Books = new List<Libro>();
        }

        public void Fill(Libro libro)
        {
            Books.Add(libro);
        }

        public BookState? GetState(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            //for (int i = 0; i < _list.Count; i++)
            //{
            //    if (_list[i].Title == title)
            //    {
            //        return _list[i].State;
            //    }
            //}

            //return null;

            //foreach (var book in _list)
            //{
            //    if (book.Title == title)
            //        return book.State;
            //}

            //return null;

            return Books.FirstOrDefault(x => x.Title == title)?.State;

            //return _list.ContainsKey(title) ? _list[title].State : null;    
        }

        public void PrimaQuery()
        {
           var res = Books.GroupBy(x => x.Customer);
           foreach (var customer in res)
            {
                Console.WriteLine(customer.Key);
                Console.WriteLine(customer.Count());
            }
        }

        public void SecondaQuery()
         {
             var res = Books.Where(x => x.State == BookState.Available).GroupBy(x => x.Customer);
             foreach(var customer in res)
             {
                Console.WriteLine(customer.Key);
                foreach(var book in customer) 
                {
                    Console.WriteLine(book.Title);
                }
            }
         } 

        public void TerzaQuery()
        {
            var res = Books.GroupBy(x => x.Customer)
                      .Select(g => new {customer = g.Key, numberOfReviews = g.Select(g => g.NumRecensioni).Sum()}).ToList();

            foreach (var customer in res)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
