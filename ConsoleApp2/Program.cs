using ConsoleApp2.Biblioteca;
using ConsoleApp2.BookModel.Dto;
using ConsoleApp2.Linq;
using ConsoleApp2.Model;
using ConsoleApp2.Model.Dto;
using ConsoleApp2.Model.Interface;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var biblio = new BookSharing();
            biblio.ChangeNumOfReviews += Biblio_ChangeReviewStatus;

            biblio.Fill(new Libro("Il Conte di Montecristo", BookState.NotAvailable, "Salvo", 4));
            biblio.Fill(new Libro("Io Uccido", BookState.NotAvailable, "Noemi", 3));
            biblio.Fill(new Libro("La svastica sul sole", BookState.Available, "Salvo", 5));
            biblio.Fill(new Libro("1984", BookState.Available, "Salvo", 5));
            biblio.Fill(new Libro("Le barzellette di Cassano", BookState.Available, "Angy", 2));
            biblio.Fill(new Libro("Ragazze elettriche", BookState.Available, "Laura", 4));

            //biblio.ShowAmount();

            biblio.Reserve("1984", "George Orwell", (title) => {
                Console.WriteLine($"è stato riservato il libro {title}");
            });

            biblio.Release("1984", "George Orwell", (title) => {
                Console.WriteLine($"è stato rilasciato il libro {title}");
            });

            biblio.AddTodayDateToBooks();

            biblio.ShowReserved();

            Menu(biblio);

        }

        private static void Biblio_ChangeReviewStatus(object sender, ChangeReviewStatusEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Il libro {e.Title} ha {e.Review} recensioni");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Beep();
        }

        public static void Menu(BookSharing biblioInsert)
        {
            var choice = '0';

            do
            {
                Console.WriteLine("\n\n1. Restituisci i libri in ordine alfabetico");
                Console.WriteLine("2. Inserisci un nuovo libro");
                Console.WriteLine("3. Prenota un nuovo libro");
                Console.WriteLine("4. Restituisci il libro");
                Console.WriteLine("5. Esci");

                Console.WriteLine("\nInserisci un'opzione numerica: ");
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '2':
                        InsertTitle(biblioInsert);
                        break;
                }
            }
            while (choice != '5');
        }

        public static void InsertTitle(BookSharing biblioInsert)
        {
            string titoloLibro;
            Console.WriteLine("\n\nInserisci il titolo del libro: ");
            titoloLibro = Console.ReadLine();

            biblioInsert.Fill(new Libro(titoloLibro, BookState.Available));

        }
    }
}