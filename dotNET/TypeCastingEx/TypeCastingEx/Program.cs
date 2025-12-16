

class BoxingUnboxingEx {


    static void Main(string[] args) {

        int x = 100;     // value type
        String str = "Dikshita";     //referance type
        Object obj = new Object(); // 'Object' is the base type of all types in C#
        obj = new object();

        

        // BOXING: value type (int) is wrapped into an object (reference type)
        obj = x;
        Console.WriteLine("Boxed value : " +obj);

        // UNBOXING: extracting the value type back from the object
        int y =(int)obj;
        Console.WriteLine("Unboxed value : " +y);



        // Conversion: turning int into string
        str = Convert.ToString(x); //Converts the integer value into its string
        Console.WriteLine(str);
        
        
        String str2 = x.ToString();//Another way to convert the integer into a string using the ToString() method
        Console.WriteLine(str2);
    }

  

}