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
                int r = random.Next(100, 10001);
                if (i < a)
                {
                    threads[i] = new Thread(() => Transaction(r))
                    {
                        Name = string.Format("Client_{0}_{1}", i + 1, 1)
                    };
                    Console.WriteLine(threads[i].Name + " created");
                }
                else
                {
                    threads[i] = new Thread(() => Transaction(r))
                    {
                        Name = string.Format("Client_{0}_{1}", (i + 1) - a, 2)
                    };
                    Console.WriteLine(threads[i].Name + " created");
                }
            }

            for(int i=0; i < total; i++)
            {
                threads[i].Start();
            }

            for (int i = 0; i < total; i++)
            {
                threads[i].Join();
            }

            //int diff = Math.Abs(a - b);
            //for(int i=0; i < diff; i ++)
            //{
            //    threads[i].Start();
            //    threads[i + a].Start();
            //}
            //if (b > a)
            //{
            //    for(int i = a + diff; i < total; i++)
            //    {
            //        threads[i].Start();
            //    }
            //}
            //if(a > b)
            //{
            //    for(int i = total-b-diff; i <)
            //}


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
                    amount -= money;
                    Console.WriteLine("The client {0} has successfully withdraw {1}rsd on cash machine no.{2}. Remaining amount of money: {3} ", client, money, cashMachine, amount);
                   
                
                }
            }

        }

    }
}
