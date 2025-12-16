
using System;

namespace OopBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Int32 x = 100;
            System.Int32 y = 200;
            Int32 z = 100;
            Int32 q = 200;
            int f = 100;
            int g = 200;

            MyClass obj = new MyClass();
            obj.GetMessage();
        }

    }
    public class MyClass
    {
        public void GetMessage()
        {
            Console.WriteLine("Hello from MyClass");
        }
    }

}