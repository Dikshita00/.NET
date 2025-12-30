using System;
using System.Threading;

namespace Threading
{
    internal class Program
    {
        // worker method

        static void methodOne()
        {
            Console.WriteLine("Method Started using {0}", Thread.CurrentThread.Name);
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Method count{0}", i);

            }
            Console.WriteLine("Method Ended using {0}", Thread.CurrentThread.Name);
        }
        static void methodTwo()
        {
            Console.WriteLine("Method-2 startedusing {0}", Thread.CurrentThread.Name);
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Method-2 count: {0}", i);
                if (i == 2)
                {
                    Console.WriteLine("Execution code started");
                    Thread.Sleep(5000);
                    Console.WriteLine("Execution code completed");
                }

            }
            Console.WriteLine("Mehod 2 ended using {0}", Thread.CurrentThread.Name);
        }

        static void methodThree()
        {
            Console.WriteLine("Method-3 started using {0}", Thread.CurrentThread.Name);
            for (int i = 0; i <= 5; i++) {
                Console.WriteLine("Method-3 count :{0}", i);
            }
            Console.WriteLine("Method-3 ended using {0}", Thread.CurrentThread.Name);
        }
        static void F1()
        {
            Console.WriteLine("F1 method execution started");
            Thread.Sleep(5000);
            Console.WriteLine("method F1 is awake");
            Console.WriteLine("F1 execution complete");
        }
        static void F2()
        {
            Console.WriteLine("F2 method execution started");
        }

        static void Main(string[] args) { 
            Thread t=Thread.CurrentThread;
            t.Name = "Main Thread";
            Console.WriteLine(t.ManagedThreadId);
            Console.WriteLine(t.Name);

            methodOne();
            methodTwo();
            methodThree();

            Thread t1 = new Thread(methodOne) { Name = "th 01" };
            Thread t2 = new Thread(methodTwo) { Name = "th 02" };
            Thread t3=new Thread(methodThree) { Name = "th 03"};

            t1.Start();
            t2.Start();
            t3.Start();

            ThreadStart ts = new ThreadStart(() =>
            {
                Console.WriteLine("Method Call...");
            });
            Thread t4 = new Thread(ts);
            t4.Start();

            Console.WriteLine("Main method execution started");

            Thread t5 = new Thread(Program.F1);
            t5.Start();
            Thread t6 = new Thread(Program.F2);                             
            t6.Start();

            if (t5.Join(2000))
            {
                Console.WriteLine("F1execution completed");
            }
            t6.Join();
            Console.WriteLine("F1 execution complete");

            if (t5.IsAlive)
            {
                Console.WriteLine("F1 execution is still going on");
            }
            else
            { 
                Console.WriteLine("F1 execution is completed");
            }
            Console.WriteLine("Main method execution complete");

        }

    }
    }

