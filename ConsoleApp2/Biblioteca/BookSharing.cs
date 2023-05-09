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

        public void ShowAmount()
        {
            Console.WriteLine($"Il numero di libri aggiunto è {_books.Count } "); 

        }

        public BookState? GetState(string title)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            //for (int i = 0; i < _books.Count; i++)
            //{
            //    if (_books[i].Title == title)
            //    {
            //        return _books[i].State;
            //    }
            //}

            //return null;

            //foreach (var book in _books)
            //{
            //    if (book.Title == title)
            //        return book.State;
            //}

            //return null;

            if (_books.ContainsKey(title))
                return _books[title].State;

            return null;

            //return _books.ContainsKey(title) ? _books[title].State : null;    
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
                //OnChangeBookStatus(title, BookState.NotAvailable);
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
                    //OnChangeBookStatus(title, BookState.Available); 
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
