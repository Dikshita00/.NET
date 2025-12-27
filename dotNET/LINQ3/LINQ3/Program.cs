using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ3
{
    public class Holder
    { 
        public int HId {  get; set; }
        public string HName { get; set; }    
        public string HAddress { get; set; }

        public void GetDetails()
        {
            Console.WriteLine($"Id: {this.HId}, Name: {this.HName}, Address: {this.HAddress}");
        }

    }
    public class Emp
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string Address { get; set; }

        public void GetDetails()
        { 
            Console.WriteLine($"Id: {this.Id}, Name: {this.Name}, Address: {this.Address}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            var intResult = from element in arr
                            orderby element descending
                            select element;
            Console.WriteLine("LINQ to int[] collection :");
            foreach (var item in intResult)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            List<Emp> emps = new List<Emp>()
            {
                new Emp(){ Id=11, Name="Ganesh", Address="Pune"},
                new Emp(){ Id=12, Name="Suresh",Address="Mumbai"},
                new Emp(){ Id=13, Name="Mitesh",Address="Pune"},
                new Emp(){ Id=14, Name="Rupesh",Address="Patna"},
                new Emp(){ Id=15, Name="Jignesh",Address="Pune"},
                new Emp(){ Id=16, Name="Jayesh",Address="Pune"},
                new Emp(){ Id=17, Name="Gukesh",Address="Mumbai"},
                new Emp(){ Id=18, Name="Prathamesh",Address="Puri"},
                new Emp(){ Id=19, Name="Mukesh",Address="Nashik"},
            };
            // Lazy Loading of LINQ
            Console.WriteLine("Enter city start character:");
            string? city = Console.ReadLine()?.ToLower();
            
            var lazyResult = from emp in emps
                             where emp.Address.ToLower().StartsWith(city)
                             select emp;
            emps.Add(new Emp() { Id = 20, Name = "Rakesh", Address = "Nashik" });
            foreach (var emp in lazyResult)

            { 
                emp.GetDetails();
            }
            Console.WriteLine();

            // LINQ with .ToList() Extension method
            var listResult = (from emp in emps
                              where emp.Address.ToLower().StartsWith(city)
                              select emp).ToList();
            emps.Add(new Emp() { Id = 21, Name = "Mahesh", Address = "Mumbai" });
            Console.WriteLine("LINQ with .ToList(): ");
            foreach (var emp in listResult)
            {
                emp.GetDetails();
            }
            Console.WriteLine();

            // LINQ with Tuple syntax

            var tupleResult = (from emp in emps
                               where emp.Address.ToLower().StartsWith(city)
                               select (emp.Name, emp.Address)).ToList();

            Console.WriteLine("LINQ with tuple syntax:");
            foreach (var element in tupleResult)
            {
                Console.WriteLine($"{element.Name} {element.Address}");
            }
            Console.WriteLine();
            // LINQ with Holder class
            var holderResult = (from emp in emps
                                where emp.Address.ToLower().StartsWith(city)
                                select new Holder() { HName = emp.Name, HAddress = emp.Address }).ToList();
            Console.WriteLine("LINQ with HGolder class:");
            foreach (var holder in holderResult)
            { 
                holder.GetDetails();
            }
            Console.WriteLine();
            // LINQ with Anonymous Type

            var anonResult = (from emp in emps
                              where emp.Address.ToLower().StartsWith(city)
                              select new { id = emp.Id, add = emp.Address }).ToList();

            Console.WriteLine("LINQ with Anonymous Type:");
            foreach (var aType in anonResult)
            {
                Console.WriteLine($"Id = {aType.id}, Address = {aType.add}");
            }
        }
    }
}