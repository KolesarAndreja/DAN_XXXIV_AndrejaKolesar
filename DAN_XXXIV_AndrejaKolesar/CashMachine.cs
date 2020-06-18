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
        public int counterATM1 = 1;
        public int counterATM2 = 1;

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
                }
                else
                {
                    threads[i] = new Thread(() => Transaction(r))
                    {
                        Name = string.Format("Client_{0}_{1}", (i + 1) - a, 2)
                    };
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

        }
        public void Transaction(int money)
        {
            var current = Thread.CurrentThread.Name;
            string[] arr = current.Split('_');
            string client = arr[1];
            string cashMachine = arr[2];

            if(cashMachine == "1")
            {
                while (Convert.ToInt32(client) > counterATM1)
                {
                    Thread.Sleep(0);
                }
            }

            if(cashMachine == "2")
            {
                while(Convert.ToInt32(client) > counterATM2)
                {
                    Thread.Sleep(0);
                }
            }

            lock (locker)
            {
                if (money > amount)
                {
                    Console.WriteLine("The client {0} failed to withdraw {1}rsd on ATM {2}.", client, money, cashMachine);
                }
                else
                {
                    amount -= money;
                    Console.WriteLine("The client {0} has successfully withdraw {1}rsd on ATM {2}. Remaining amount of money is {3}rsd.", client, money, cashMachine, amount);
                }

                if(cashMachine == "1")
                {
                    counterATM1++;
                }
                if (cashMachine == "2")
                {
                    counterATM2++;
                }
            }

        }

    }
}
