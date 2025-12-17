using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityInheritance.logic
{

    /*
     In C#, internal is an access modifier.

    It specifies that the type or member is accessible only within the same assembly (project).

    An assembly is basically the compiled output of your project (like a .dll or .exe).
     */
    internal class Person
    {
        public string first_name;
        public string last_name;

    }
    internal class Employee : Person {

        public int employee_id;
    
    }
}
