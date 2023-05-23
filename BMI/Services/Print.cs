using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIApp.Services
{
    internal class Print
    {

        public static void printMenu()
        {
            Console.WriteLine("1) Add Member");
            Console.WriteLine("2) Delete Member");
            Console.WriteLine("3) Edit Member");
            Console.WriteLine("4) BMI");
            Console.WriteLine("Please enter a number between 1 and 5 : ");
        }
        public static void PrintEditMenu()
        {
            Console.WriteLine("1) Name");
            Console.WriteLine("2) LastName");
            Console.WriteLine("3) Code Melli");
            Console.WriteLine("4) Age");
            Console.WriteLine("5) Phone");
            Console.WriteLine("6) Exit");
        }

    }
}
