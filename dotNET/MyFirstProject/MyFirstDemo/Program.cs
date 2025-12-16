using System;

public abstract class Employee
{
    public abstract void EmpInfo();
    public abstract void EmpRoll();
}

public class EmployeeImpl : Employee
{
    public override void EmpInfo() => Console.WriteLine("inside EmpInfo");
    public override void EmpRoll() => Console.WriteLine("inside EmpRoll");
}

public class Program
{
    public static void Main(string[] args)
    {
        // hello world
        Console.WriteLine("Hello, World!");

        // addition
        int x = 10, y = 20;
        Console.WriteLine(x + y);

        // if-else
        int age = 20;
        Console.WriteLine(age <= 18 ? "Age Criteria not fulfilled" : "You are good to go");

        // prime check
        int num = 35;
        bool isPrime = true;
        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0) { isPrime = false; break; }
        }
        Console.WriteLine(isPrime ? "Prime number" : "Not prime");

        // abstract class demo
        Employee emp = new EmployeeImpl();
        emp.EmpRoll();
        emp.EmpInfo();

        Console.ReadLine(); // keeps console open
    }
}
