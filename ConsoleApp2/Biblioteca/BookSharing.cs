using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace ConsoleApp2.Biblioteca
{
    public class BookSharing
    {
        private Dictionary<string, Libro> _books;

        public BookSharing()
        {
            _books = new Dictionary<string, Libro>();
        }

        public void Fill(Libro libro)
        {
            if (!_books.ContainsKey(libro.Title))
                _books.Add(libro.Title, libro);
        }

        public void BooksOrderedByTitle()
        {
            var orderedBooks = _books.Values.OrderBy( x => x.Title);
            Console.WriteLine("i libro in ordine alfabetico sono: ");
            foreach (Libro book in orderedBooks) 
            {
                Console.WriteLine(book.Title);
            }
        }
        public void ShowReserved() 
        {
            var reserved = 0;
            foreach (Libro libro in _books.Values) 
            {
                if(libro.State == BookState.NotAvailable)
                {
                    reserved++;
                }
            }
            Console.WriteLine($"I libri prenotati sono : {reserved}");
        }

        public void ShowAmount()
        {
            Console.WriteLine($"Il numero di libri aggiunto è {_books.Count } "); 

        }

        public BookState? GetState(string title)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));


            if (_books.ContainsKey(title))
                return _books[title].State;

            return null;

        }

        public bool Reserve(string title, string customer, Action <string> reserve)
        {
            if (String.IsNullOrEmpty(customer))
                throw new ArgumentNullException(nameof(customer));

            var state = GetState(title);

            if (state != null && state == BookState.Available)
            {
                _books[title].State = BookState.NotAvailable;
                _books[title].Customer = customer;
                reserve(title);
                return true;
            }

            return false;
        }

        public bool InteractiveReserve(string title, string customer)
        {
            if (String.IsNullOrEmpty(customer))
                throw new ArgumentNullException(nameof(customer));

            var state = GetState(title);

            if (state != null && state == BookState.Available)
            {
                _books[title].State = BookState.NotAvailable;
                _books[title].Customer = customer;
                return true;
            }

            return false;
        }

        public void Release(string title, string customer, Action <string> release)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            if (String.IsNullOrEmpty(customer))
                throw new ArgumentNullException(nameof(customer));

            if ( _books.ContainsKey(title))
            {
                if (_books[title].Customer == customer)
                {
                    _books[title].State = BookState.Available;
                    _books[title].Customer = null;
                    release(title);
                }
            }
        }
                
        public void AddTodayDateToBooks()
        {
            var bookTitle = _books.Keys.ToList();
            Parallel.For(0, bookTitle.Count,new ParallelOptions() { MaxDegreeOfParallelism = 2},
                  index =>
                  {
                      string title = bookTitle[index];
                      StringBuilder s = new StringBuilder();
                      s.Append(title);
                      s.Append(" ");
                      s.Append(DateTime.Now.ToString("M/d/yyyy"));
                      _books[title].Title = s.ToString();
                      Console.WriteLine(_books[title].Title);
                  });
        }

        public event EventHandler<ChangeBookStatusEventArgs> ChangeBookStatus;

        private void OnChangeBookStatus(string title, BookState bookState)
        {
            var handler = ChangeBookStatus;
            if (handler != null)
                handler(this, new ChangeBookStatusEventArgs()
                {
                    BookState = bookState,
                    Title = title,  
                });
        }

        public event EventHandler<ChangeReviewStatusEventArgs> ChangeNumOfReviews;

        public void AddNewReview(string title, int review)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
           
            if (_books.ContainsKey(title))
            {
                _books[title].NumRecensioni += review;
                OnChangeNumOfReviews(title, _books[title].NumRecensioni);
            }
        }

        public void OnChangeNumOfReviews(string title, int review)
        {
            var handler = ChangeNumOfReviews;
            if (handler != null)
                handler(this, new ChangeReviewStatusEventArgs()
                {
                    Review = review,
                    Title = title,
                });
        }
    }
}
