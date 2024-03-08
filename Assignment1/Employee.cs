using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Employee
    {
        private int Id;
        private string Name;
        private string DepartmentName;
        public delegate void PrintCalledEventHandler();
        public Employee(int id, string name, string departmentName)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;


        }

        public int GetId()
        {
            PrintCalledEventHandler EventCalled;
            EventCalled += GetId;
            EventCalled("On Getid called");
            return Id;
        }

        public string GetName()
        {
            //PrintCalledEventHandler OnMethodCalled("GetName() method called");
            return Name;
        }

        public string GetDepartmentName()
        {
            //PrintCalledEventHandler OnMethodCalled("GetDepartmentName() method called");
            return DepartmentName;
        }

        protected virtual void OnMethodCalled(string e)
        {
            System.Console.WriteLine(e);
        }

    }
}