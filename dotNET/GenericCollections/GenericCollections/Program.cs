using System;
using System.Collections.Generic;

namespace GenericCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Emp emp1 = new Emp { EId = 101, EName = "Hugh Jackman", EAddress = "Sydney, Australia" };
            Emp emp2 = new Emp { EId = 102, EName = "Tony Stark", EAddress = "Shivaji Nagar" };
            Emp emp3 = new Emp { EId = 103, EName = "Tom Ellis", EAddress = "L.A" };

            // List<T> Example
            List<Emp> emps = new List<Emp> { emp1, emp2, emp3 };
            Console.WriteLine("Employees from List<T>:");
            foreach (Emp emp in emps)
            {
                Console.WriteLine($"Id: {emp.EId}, Name: {emp.EName}, Address: {emp.EAddress}");
            }

            // Dictionary<TKey, TValue> Example
            Dictionary<int, Emp> empDict = new Dictionary<int, Emp>
            {
                { emp1.EId, emp1 },
                { emp2.EId, emp2 },
                { emp3.EId, emp3 }
            };

            Console.WriteLine("\nEmployees from Dictionary<TKey, TValue> (KeyValuePair iteration):");
            foreach (KeyValuePair<int, Emp> element in empDict)
            {
                Emp emp = element.Value;
                Console.WriteLine($"Id: {emp.EId}, Name: {emp.EName}, Address: {emp.EAddress}");
            }

            Console.WriteLine("\nEmployees from Dictionary<TKey, TValue> (Keys iteration):");
            foreach (int key in empDict.Keys)
            {
                Emp emp = empDict[key];
                Console.WriteLine($"Key = {key}, Id: {emp.EId}, Name: {emp.EName}, Address: {emp.EAddress}");
            }

            Console.WriteLine("\nEmployees from Dictionary<TKey, TValue> (Values iteration):");
            foreach (Emp emp in empDict.Values)
            {
                Console.WriteLine($"Id: {emp.EId}, Name: {emp.EName}, Address: {emp.EAddress}");
            }
        }
    }

    public class Emp
    {
        public int EId { get; set; }
        public string EName { get; set; }
        public string EAddress { get; set; }
    }
}
