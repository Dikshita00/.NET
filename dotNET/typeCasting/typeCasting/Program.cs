class TypeCastingEx {

    static void Main(string[] args) {

        //type casting
        int intVariable = 100;
        double doubleVariable = intVariable;
        Console.WriteLine("Implicit casting int to double: " + doubleVariable );

        double x = 568.57;
        int i = (int)x;
        Console.WriteLine("Explicit casting idouble to int: "+ i);



    }

}