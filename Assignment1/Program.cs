
using System;
namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter employee ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter employee department name:");
            string departmentName = Console.ReadLine();

            // Create employee object
            Employee employee = new Employee(id, name, departmentName);

            // Print employee details
            Console.WriteLine($"ID: {employee.GetId()}");
            Console.WriteLine($"Name: {employee.GetName()}");
            Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");

        }
    }
}

