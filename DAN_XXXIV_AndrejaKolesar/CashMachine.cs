using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_AndrejaKolesar
{
    class CashMachine
    {
        public int amount = 10000;
        private object locker = new object();


        public void ThreadsMaker(int a, int b)
        {
            int total = a + b;
            Thread[] threads = new Thread[total];
            Random random = new Random();
            for(int i = 0; i < total; i++)
            {
                if (i < a)
                {
                    threads[i] = new Thread(() => Transaction(random.Next(100, 10001)))
                    {
                        Name = string.Format("Client_{0}_{1}", i + 1, 1)
                    };
                    Console.WriteLine(threads[i].Name + " created");
                }
                else
                {
                    threads[i] = new Thread(() => Transaction(random.Next(100, 10001)))
                    {
                        Name = string.Format("Client_{0}_{1}", (i + 1) - a, 2)
                    };
                    Console.WriteLine(threads[i].Name + " created");
                }
            }
            ThreadsStarter(threads);
        }

        public void ThreadsStarter(Thread[] t)
        {
            

        }


        public void Transaction(int money)
        {
            var current = Thread.CurrentThread.Name;
            string[] arr = current.Split('_');
            string client = arr[1];
            string cashMachine = arr[2];

            lock (locker)
            {
                if (money > amount)
                {
                    Console.WriteLine("The client {0} failed to withdraw {1}rsd on cash machine no.{2}.", client, money, cashMachine);
                }
                else
                {
                    Console.WriteLine("The client {0} has successfully withdraw {1}rsd on cash machine no.{2}.", client, money, cashMachine);
                    amount -= money;
                    Console.WriteLine("Remaining amount of money: " + amount);
                }
            }

        }

    }
}
