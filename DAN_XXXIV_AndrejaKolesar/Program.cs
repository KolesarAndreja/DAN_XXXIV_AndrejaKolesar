using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_AndrejaKolesar
{
    class Program
    {
        /// <summary>
        /// Ask user for number of clients of ATM1 and ATM2
        /// </summary>
        public static void AppMethod()
        {
            Console.Write("Enter number of persons for ATM1:");
            int a = Validation.ValidPositiveNumber();

            Console.Write("Enter number of persons for ATM2:");
            int b = Validation.ValidPositiveNumber();

            CashMachine cashMachine = new CashMachine();
            cashMachine.ThreadsMaker(a, b);
            Console.WriteLine();
        }

        /// <summary>
        /// Main containts menu for application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string s = "";
            Console.Write("1.Enter application \n2.Exit application \nYour choice: ");
            do
            { 
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        AppMethod();
                        Console.Write("1.Enter application \n2.Exit application \nYour choice: ");
                        break;
                    case "2":
                        break;
                    default:
                        Console.Write("Invalid input. Try again: ");
                        break;
                }
            } while (s!="2");
        }
    }
}
