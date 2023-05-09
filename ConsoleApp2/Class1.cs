
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp2
{
    /// <summary>
    /// <seealso cref=""/>
    /// </summary>
    public class ClassWorkspace
    {
        //ciao sono un commento
        /*
         
        Ciao sono un commento lungo
         
         */
        private string _firstName;


        public int MyProperty { get; set; }

        public void OnRun(string firstName)
        {
            _firstName = "Giulia";
            _firstName = "Paolo";

            _firstName = _firstName + " Rossi";

            _firstName = string.Concat(_firstName, " Rossi");

            DateTime date = new DateTime();

            _firstName = String.Format("The {0} student has been hill yerstarday. {1} {2} {3:MM#dd.yyyy}", _firstName, "Blue", "Grreen", DateTime.Now);


            CultureInfo info = new CultureInfo("en-US");
            var info5 = new CultureInfo("it-IT");

            _firstName = _firstName + Environment.NewLine + " Pippo";

            StringBuilder sb = new StringBuilder();

            sb.Append("dddd");
            sb.Append("dddd sss");
            sb.Append("fghgh");
            sb.Append("ytyut");
            sb.AppendLine("ttttt");
            sb.Append("ggg");
            sb.AppendFormat("ggg {0}", "ttt");
            Console.Write(sb.ToString());
        }
    }
}
