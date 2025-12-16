

using System;

class TypeCastingEx
{
    static void Main(string[] args)
    {
        // Boxing
        int x = 12321;          // value type
        object obj = x;         // boxing: int → object
        Console.WriteLine("Boxing: " + obj);

        // Unboxing
        int a = (int)obj;       // unboxing: object → int
        Console.WriteLine("Unboxing: " + a);

        // Conversion example
        string str1 = "456";
        int p = Convert.ToInt32(str1);   // valid conversion string → int
        Console.WriteLine("Converted string to int: " + p);

       
    }
}
