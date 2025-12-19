using System;

namespace Delegates
{
    // 1. Delegates (type-safe function pointers)
    public delegate void MyDelegate();
    public delegate void MyDelegate2(string str);
    public delegate int MyAddDelegate(int p, int q);
    public delegate int MySquareDelegate(int x);

    // 2. Core Classes
    public class CMath
    {
        public int Add(int x, int y) => x + y;
        public int Square(int x) => x * x;
    }

    public class MyClass
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }

        public void Greet(string name)
        {
            Console.WriteLine($"Hello {name}!!");
        }
    }

    // 3. Entry Point
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Demo: Delegates with methods ---
            // Direct method call
            SayHi();

            // Instance method call
            MyClass myClass = new MyClass();
            myClass.SayHello();

            // Delegate pointing to static method
            MyDelegate del1 = new MyDelegate(SayHi);
            del1.Invoke();

            // Delegate pointing to instance method
            MyDelegate del2 = new MyDelegate(myClass.SayHello);
            del2.Invoke();

            // Delegate with parameter
            MyDelegate2 del3 = new MyDelegate2(myClass.Greet);
            del3("Hugh Jackman");

            MyDelegate2 del4 = new MyDelegate2(SaySomething);
            del4("Mando");

            // --- Demo: Delegates with math operations ---
            CMath cMath = new CMath();

            MyAddDelegate addDel = new MyAddDelegate(cMath.Add);
            Console.WriteLine("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int addResult = addDel(num1, num2);

            MySquareDelegate squareDel = new MySquareDelegate(cMath.Square);
            int squareResult = squareDel(num1);

            Console.WriteLine($"Add = {addResult}, Square = {squareResult}");
        }

        static void SayHi()
        {
            Console.WriteLine("Hi");
        }

        static void SaySomething(string name)
        {
            Console.WriteLine($"Hi {name}");
        }
    }
}
