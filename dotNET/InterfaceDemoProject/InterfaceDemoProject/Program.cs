
namespace InterfaceDemoProject
{
    public interface IDrink
    {
        void GetDrink();
    }

    public interface IX
    {
        int Add(int x, int y);
        int Sub(int x, int y);
    }

    public interface IY
    { 
        int Add(int x, int y);
        int Mult(int x, int y);
    }

    public interface IDemo
    { 
        int Div(int x, int y);
        void Log(string nmessage);
    }

    //classes implementing interface

    public class ColdDrink : IDrink
    {
        public void GetDrink()
        {
            Console.WriteLine("Enjoy your cold drink!!!");
        }
    }

    public class HotDrink : IDrink 
    {
        public void GetDrink()
        {
            Console.WriteLine("Enjoy your hot drink!!!");
        }
    }

    //MyMath implements Iy and IDemo

    public class MyMath : IY, IDemo
    {
        public int Add(int x, int y)
        { 
            return x+ y;
        }

        public int Div(int x, int y)
        {
            return x / y;
        }

        void IDemo.Log(string nmessage)
        {
            
            Console.WriteLine("Log msg : {0} ",nmessage);

        }

        public int Mult(int x, int y)
        {
            return x * y;
        }
    }
    // PROGRAM ENTRY POINT

    internal class Program
    {
        static void Main(string[] args)
        { 
            MyMath demo = new MyMath();
            Console.WriteLine("Add : " + demo.Add(10, 20));
            Console.WriteLine("Div :"+ demo.Div(20,20));
            Console.WriteLine("Mult :"+demo.Mult(10,20));


        }

    }

}