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
        public static void AppMethod()
        {
            Console.Write("Enter number of persons for first cash machine:");
            int a = Validation.ValidPositiveNumber();

            Console.Write("Enter number of persons for second cash machine:");
            int b = Validation.ValidPositiveNumber();

            CashMachine cashMachine = new CashMachine();
            cashMachine.ThreadsMaker(a, b);


            Console.WriteLine();
        }
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
