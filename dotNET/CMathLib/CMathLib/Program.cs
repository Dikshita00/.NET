using System;

namespace CMathLib
{
    // Base Math class
    public class CMath
    {
        // Public: accessible everywhere
        public void Add(int x, int y)
        {
            Console.WriteLine($"Add = {x + y}");
        }

        // Private: accessible only inside this class
        private void Sub(int x, int y)
        {
            Console.WriteLine($"Sub = {x - y}");
        }

        // Protected: accessible in derived classes
        protected void Mult(int x, int y)
        {
            Console.WriteLine($"Mult = {x * y}");
        }

        // Internal: accessible only within this assembly
        internal void Div(int x, int y)
        {
            Console.WriteLine($"Div = {x / y}");
        }

        // Protected Internal: accessible in derived classes and within this assembly
        protected internal void Square(int x)
        {
            Console.WriteLine($"Square = {x * x}");
        }
    }

    // Advanced Math class extending CMath
    public class AdvMath : CMath
    {
        public void Adv_WrapperMethod()
        {
            // Accessing protected/internal members from base
            base.Div(50, 5);
            base.Mult(5, 5);
            base.Square(3);
        }
    }
}
