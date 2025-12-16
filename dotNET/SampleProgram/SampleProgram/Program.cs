using System;

namespace InheritanceWithConstructorChaining
{
    internal class BaseClass
    {
        private int _index;

        public BaseClass()
        {
            Console.WriteLine("BaseClass default constructor called");
        }

        public BaseClass(int num)
        {
            _index = num;
            Console.WriteLine("BaseClass parameterized constructor: you passed num = {0}", _index);
        }

        public void Method1()
        {
            Console.WriteLine("Method from Base Class");
        }
    }

    internal class DerivedClass : BaseClass
    {
        public DerivedClass(int no) : base(no)
        {
            Console.WriteLine("DerivedClass constructor called with no = {0}", no);
        }

        public void Method2()
        {
            Console.WriteLine("Method from Derived class");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Demonstrates inheritance and polymorphism:

            BaseClass baseObj = new BaseClass();   // Calls BaseClass default constructor
            baseObj.Method1();

            DerivedClass derivedObj = new DerivedClass(10); // Calls DerivedClass constructor, which chains to BaseClass(int)
            derivedObj.Method1();   // Inherited from BaseClass
            derivedObj.Method2();   // Defined in DerivedClass

            BaseClass obj = new DerivedClass(20);  // Polymorphism: BaseClass reference to DerivedClass object
            obj.Method1();          // Calls BaseClass Method1 (since not overridden)
          
        }
    }
}
