using System;

namespace DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Demonstration of various data types in C#
            int x = 42;
            System.Int32 y = 100;
            double d = 3.14159;
            Console.WriteLine("X = {0}, y={1}, d ={2}", x, y, d);

            string str = "Hello Disha";
            string str2 = "Hello Dikshita";
            string str3 = "abc";   // simpler way to create a string
            char ch = 'A';
            char[] charr = new char[2];
            charr[0] = 'H';
            charr[1] = 'i';
            string str4 = new string(charr);

            #region If-else
            bool isRaining = true;
            if (isRaining)
            {
                Console.WriteLine("Take an umbrella");
            }
            else
            {
                Console.WriteLine("No need to take an umbrella");
            }
            #endregion

            #region for loop
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }
            #endregion

            #region while
            int z = 5;
            while (z > 0)
            {
                Console.WriteLine(z);
                z--;
            }
            #endregion

            #region do-while
            int e = 5;
            do
            {
                Console.WriteLine(e);
                e--;
            } while (e > 0);   // FIXED: condition depends on e, not x
            #endregion

            #region switch-case
            Console.WriteLine("Enter your Choice");
            string input = Console.ReadLine();
            int choice = Convert.ToInt32(input);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You selected option 1");
                    break;
                case 2:
                    Console.WriteLine("You selected option 2");
                    break;
                case 3:
                    Console.WriteLine("You selected option 3");
                    break;
                default:
                    Console.WriteLine("Invalid option selected");
                    break;
            }
            #endregion

            #region Boxing and Unboxing and Type-casting

            #region Boxing
            int f = 100;
            object obj1 = f;   // boxing: int → object
            Console.WriteLine("Boxed value: " + obj1);

            str = Convert.ToString(x);   // conversion int → string
            string str7 = x.ToString();  // another conversion
            #endregion

            #region Unboxing
            // Unboxing: Converting Reference Type back to Value Type
            int q = (int)obj1; // unboxing: object → int
            Console.WriteLine("Unboxed value q = {0}", q);

            // NOTE: str2 = "Hello Dikshita" cannot be converted to int directly
            // If you want to demonstrate conversion, use a numeric string:
            string numericString = "123";
            int p = Convert.ToInt32(numericString);
            Console.WriteLine("Converted string to int p = {0}", p);
            #endregion

            #region Type-casting
            double g = 9.18;
            int num1 = (int)g;   // explicit cast: double → int
            double g2 = num1;    // implicit widening: int → double
            Console.WriteLine("g = {0}, num1 = {1}, g2 ={2}", g, num1, g2);

            object obj2 = str4;  // boxing string into object (reference assignment)
            string str5 = obj2.ToString(); // conversion back to string
            Console.WriteLine("str5 = " + str5);
            #endregion

            #endregion
        }
    }
}
