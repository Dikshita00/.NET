using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 5; // height of half diamond

        // Upper half
        for (int i = 1; i <= n; i++)
        {
            // Print leading spaces
            for (int j = i; j < n; j++)
                Console.Write(" ");

            // Print stars with hollow inside
            for (int j = 1; j <= (2 * i - 1); j++)
            {
                if (j == 1 || j == (2 * i - 1))
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
            
        }

        // Lower half
        for (int i = n - 1; i >= 1; i--)
        {
            // Print leading spaces
            for (int j = n; j > i; j--)
                Console.Write(" ");

            // Print stars with hollow inside
            for (int j = 1; j <= (2 * i - 1); j++)
            {
                if (j == 1 || j == (2 * i - 1))
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
