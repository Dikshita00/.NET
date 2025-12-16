namespace InheritanceWithConstructorChaining


internal class Program
{
	static void Main(string[] args) {

        // Demonstrates inheritance and polymorphism:

        #region  
        BaseClass baseObj = new BaseClass();
        baseObj.Method1();
        derivedClass derivedObj = new derivedClass();
        derivedObj.Method1();
        derivedObj.Method2();
        BaseClass obj = new DerivedClass();
        obj.Method1();
    }

}
