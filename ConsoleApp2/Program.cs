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

            //var bike = new  Bike();

            //var t = bike.Type;

            //var speed = bike.Speed;
            //bike.Accellerate();
            //speed = bike.Speed;
            //var age = GetAge();

            //Console.WriteLine($"age: {age.Age}");

            //var esercitazione = File.ReadAllText("C:\\Users\\salvatore.aprile\\Desktop\\Academy 2023\\Slide\\01 - .NET and C# language\\Labs\\Lab02\\Esercitazione2.txt");

            //var person = new Student("Maria");

            ////var t = new Student("Carlo");
            //var t = 7;
            //person.Calculate(ref t);


            //person.FirstName = "Test";

            //var casted = (IAge)person;

            //casted. = "Test";

            //var t = new ClassWorkspace();
            //t.OnRun("ss");

            var biblio = new BookSharing();
            biblio.ChangeNumOfReviews += Biblio_ChangeReviewStatus;

            biblio.Fill(new Libro("Il Conte di Montecristo", BookState.Available, "Salvo", 4));
            biblio.Fill(new Libro("Io Uccido", BookState.Available, "Noemi", 3));
            biblio.Fill(new Libro("La svastica sul sole", BookState.Available, "Salvo", 5));
            biblio.Fill(new Libro("1984", BookState.Available, "Salvo", 5));
            biblio.Fill(new Libro("Le barzellette di Cassano", BookState.Available, "Angy", 2));
            biblio.Fill(new Libro("Ragazze elettriche", BookState.Available, "Laura", 4));

            //biblio.AddNewReview("1984", 3);
            //biblio.AddNewReview("1984", 3);
            //biblio.AddNewReview("La svastica sul sole", 5);
            biblio.ShowAmount();

            biblio.Reserve("1984", "George Orwell", (title) => {
                Console.WriteLine($"è stato riservato il libro {title}");
            });

            biblio.Release("1984", "George Orwell", (title) => {
                Console.WriteLine($"è stato rilasciato il libro {title}");
            });

            biblio.AddTodayDateToBooks();
        }



        private static void Biblio_ChangeReviewStatus(object sender, ChangeReviewStatusEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Il libro {e.Title} ha {e.Review} recensioni");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Beep();
        }

       

        //biblio.ChangeBookStatus -= Biblio_ChangeBookStatus;

        //var biblio = new BookSharingLinq();

        //biblio.Fill(new Libro("Figth club", BookState.Available, "Giulia",5));
        //biblio.Fill(new Libro("La fabbrica di cioccolato", BookState.Available, "Laura",4));
        //biblio.Fill(new Libro("Figth club", BookState.Available, "Mario",2));
        //biblio.Fill(new Libro("Into the wild", BookState.Available, "Giulia",5));

        //biblio.PrimaQuery();
        //biblio.SecondaQuery();
        //biblio.TerzaQuery();
        //biblio.Books.
    }
}
