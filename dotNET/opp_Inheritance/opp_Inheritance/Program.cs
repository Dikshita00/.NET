
namespace oop_Inheritance
{
    internal class Program
    {
        static void Main(string[] args) 
            {
            Person person = new Person();
            person.first_name = "disha";
            person.last_name = "Gaikwad";
            Console.WriteLine(person);
            Console.WriteLine("Name :{0} {1}", person.first_name, person.last_name);

            Employee employee = new Employee();
            employee.employee_id = 1001;
            Console.WriteLine("ID:{0}{1}{2}", person.first_name, person.last_name, employee.employee_id);






                

           
            }
    }
}
