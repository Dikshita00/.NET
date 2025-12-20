using System;

namespace GenericDelegate
{
    public delegate void MyDelegate();
    public delegate void MyDelegate2<T>(T para);
    public delegate void MyDelegate3<T1, T2>(T1 para1, T2 para2);
    public delegate bool PredicateDelegate<T>(T para);
    public delegate R FuncDelegate<T, R>(T para);

    internal class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            MyMath math = new MyMath();

            // MyDelegate
            MyDelegate del1 = demo.SayHi;
            del1();

            // MyDelegate2<T>
            MyDelegate2<string> del2 = demo.SayHello;
            del2("Hugh Jackman");

            MyDelegate2<int> del3 = demo.Display;
            del3(42);

            // MyDelegate3<T1, T2>
            MyDelegate3<string, string> del4 = demo.Greet;
            del4("Hugh Jackman", "The movie was really good!!");

            // PredicateDelegate<T>
            PredicateDelegate<int> pred1 = demo.CheckEven;
            bool isEven = pred1(11);
            Console.WriteLine($"isEven = {isEven} for number = 11");

            PredicateDelegate<int> pred2 = demo.CheckOdd;
            bool isOdd = pred2(7);
            Console.WriteLine($"isOdd = {isOdd} for number = 7");

            // FuncDelegate<T, R>
            FuncDelegate<int[], int> funcAdd = demo.Add;
            int sum = funcAdd(new int[] { 10, 20, 30 });
            Console.WriteLine($"Sum of array = {sum}");

            // Using out parameter with delegate
            demo.Add(5, 10, 15, out int total);
            Console.WriteLine($"Sum of three numbers = {total}");

            // Passing delegate to MyMath.Test
            MyDelegate3<string, string> delGreet = demo.Greet;
            math.Test<string, string, string, string>(delGreet, "Tom Ellis", "Good Morning!");
        }
    }

    public class Demo
    {
        public void SayHi()
        {
            Console.WriteLine("Hi there!");
        }

        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }

        public void Greet(string name, string msg)
        {
            Console.WriteLine($"Hey! {name}, {msg}");
        }

        public void Display(int number)
        {
            Console.WriteLine($"Number is: {number}");
        }

        public bool CheckEven(int number)
        {
            return number % 2 == 0;
        }

        public bool CheckOdd(int number)
        {
            return number % 2 != 0;
        }

        public int Add(int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        public void Add(int n1, int n2, int n3, out int sum)
        {
            sum = n1 + n2 + n3;
        }
    }

    public class MyMath
    {
        public void Test<T1, T2, T3, T4>(MyDelegate3<T1, T2> del, T3 para1, T4 para2)
        {
            dynamic p1 = para1;
            dynamic p2 = para2;
            del.Invoke(p1, p2);
        }
    }
}
