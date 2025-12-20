
using System;

namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Without Template Swap Method
            int a = 12;
            int b = 7;
            CMath cmath = new CMath();
            Console.WriteLine($"Before Swapping A={a}, B={b}");
            cmath.Swap(ref a, ref b);
            Console.WriteLine($"After Swapping A={a}, B={b}");

            string s1 = "Hello";
            string s2 = "Bye";
            Console.WriteLine($"Before Swapping S1={s1}, S2={s2}");
            cmath.Swap(ref s1, ref s2);
            Console.WriteLine($"After Swapping S1={s1}, S2={s2}");

            // With Template Swap Method
            int x = 12;
            int y = 7;
            Console.WriteLine($"Before Swapping X={x}, Y={y}");
            cmath.Swap<int>(ref x, ref y);
            Console.WriteLine($"After Swapping X={x}, Y={y}");

            string str1 = "Hello";
            string str2 = "Bye";
            Console.WriteLine($"Before Swapping Str1={str1}, Str2={str2}");
            cmath.Swap<string>(ref str1, ref str2);
            Console.WriteLine($"After Swapping Str1={str1}, Str2={str2}");

            // Generic Overloaded Demo Methods
            double result = cmath.Demo<int, string, double, bool>(100, "Hugh Jackman", 23.33, true);
            Console.WriteLine(result);

            char result1 = cmath.Demo<int, string, double, bool, char>(200, "Chris Hemsworth", 45.55, false, 'A');
            Console.WriteLine(result1);

            // Dynamic Type
            Console.WriteLine(cmath.Add<int>(2, 4));
            Console.WriteLine(cmath.Add<string>("2", "4"));
            Console.WriteLine(cmath.Add<double>(22.22, 22.22));

            // Out Parameter
            double area, circumference;
            double radius = 5;
            cmath.CalculateCircleArea(radius, out area, out circumference);
            Console.WriteLine($"Circle : Area = {area}, Circumference = {circumference}");

            // Generic Class With Generic and Non-Generic Methods
            MyClass<string> myClass = new MyClass<string>();
            myClass.SayHi("Hugh Jackman");
            Console.WriteLine(myClass.DoubleTheNumber(2));

            // Params Keyword
            int[] numbers = { 10, 20, 30 };
            Demo demo = new Demo();
            demo.Add(numbers);

            demo.PlayerNames(100, "Ronaldo", "Messi");
            demo.PlayerNames(200, "Ronaldo", "Messi", "Mbappe", "Neymar");
        }
    }

    public class Demo
    {
        public void Add(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine(sum);
        }

        public void PlayerNames(int x, params string[] nms)
        {
            string output = "Player Names: ";
            for (int i = 0; i < nms.Length; i++)
            {
                output += nms[i] + " ";
            }
            Console.WriteLine(output);
            Console.WriteLine(x);
        }
    }

    public class MyClass<T>
    {
        public void SayHi(T para)
        {
            Console.WriteLine($"Hello {para}");
        }

        public int DoubleTheNumber(int x)
        {
            return x * 2;
        }
    }

    public class CMath
    {
        public void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public R Demo<P, Q, R, S>(P x, Q y, R a, S b)
        {
            return a;
        }

        public T5 Demo<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 t4, T5 p5)
        {
            return p5;
        }

        public T Add<T>(T x, T y)
        {
            dynamic para1 = x;
            dynamic para2 = y;
            dynamic sum = para1 + para2;
            return sum;
        }

        public void CalculateCircleArea(double radius, out double area, out double circumference)
        {
            area = 3.14 * radius * radius;
            circumference = 2 * 3.14 * radius;
        }
    }
}
