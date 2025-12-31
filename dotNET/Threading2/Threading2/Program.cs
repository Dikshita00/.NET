using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Threading2
{
    // Core entity class
    public class Emp
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    internal class Program
    {
        // Complex dummy workload to simulate heavy computation
        public static void DoSomeThingComplex()
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    // Simulating CPU work
                }
            }
        }

        static void Main(string[] args)
        {
            // 1️⃣ Normal Method Call
            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            for (int i = 0; i < 10; i++)
            {
                DoSomeThingComplex();
            }
            watch1.Stop();
            Console.WriteLine("Normal Method Call - Time taken = {0}", watch1.ElapsedTicks);

            // 2️⃣ Using Threads
            Stopwatch watch2 = new Stopwatch();
            watch2.Start();
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(DoSomeThingComplex));
                threads.Add(t);
                t.Start();
            }
            foreach (var t in threads) t.Join(); // Wait for all threads
            watch2.Stop();
            Console.WriteLine("Thread Execution - Time taken = {0}", watch2.ElapsedTicks);

            // 3️⃣ Explicit Parallel Programming with Tasks
            Stopwatch watch3 = new Stopwatch();
            watch3.Start();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                Task t = new Task(new Action(DoSomeThingComplex));
                tasks.Add(t);
                t.Start();
                Console.WriteLine("Started Task ID: {0}", t.Id);
            }
            Task.WaitAll(tasks.ToArray()); // Wait for all tasks
            watch3.Stop();
            Console.WriteLine("Explicit Tasks - Time taken = {0}", watch3.ElapsedTicks);

            // 4️⃣ Parallel.ForEach (Implicit Parallelism)
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Stopwatch watch4 = new Stopwatch();
            watch4.Start();
            Parallel.ForEach(numbers, (num) =>
            {
                Console.WriteLine($"Number: {num}, Task Id: {Task.CurrentId}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            });
            watch4.Stop();
            Console.WriteLine("Parallel.ForEach - Time taken = {0}", watch4.ElapsedTicks);

            // 5️⃣ Parallel LINQ (PLINQ)
            List<Emp> employees = new List<Emp>()
            {
                new Emp(){ ID = 11, Name = "Jignesh", Address = "Patna"},
                new Emp(){ ID = 12, Name = "Prathamesh", Address = "Nashik"},
                new Emp(){ ID = 13, Name = "Devendra", Address = "Nagpur"},
                new Emp(){ ID = 14, Name = "Kalpesh", Address = "Kerla"},
                new Emp(){ ID = 15, Name = "Kushendra", Address = "Indore"}
            };

            var result = (from emp in employees.AsParallel()
                          where emp.Address.StartsWith("N")
                          select emp).ToList();

            Console.WriteLine("\nEmployees with Address starting with 'N':");
            foreach (var emp in result)
            {
                Console.WriteLine($"Name: {emp.Name}, Address: {emp.Address}");
            }
        }
    }
}
