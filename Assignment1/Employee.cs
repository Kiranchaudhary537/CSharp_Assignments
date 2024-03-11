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
        private object DepartmentName;
        public event EventHandler<string> PrintCalledMethod;
        public Employee(int id, string name, object departmentName)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;


        }

        public int GetId()
        {
            OnMethodCalled("\nGetId() method called");
            return Id;
        }

        public string GetName()
        {
            OnMethodCalled("\nGetName() method called");
            return Name;
        }

        public object GetDepartmentName()
        {
            OnMethodCalled("\nGetDepartmentName() method called");
            return DepartmentName;
        }

        // Method to update Employee Id
        public void UpdateEmployee(int newId)
        {
            Id = newId;
        }

        // Method to update Employee Name
        public void UpdateEmployee(string newName)
        {
            Name = newName;
        }

        // Method to update Employee DepartmentName
        public void UpdateEmployee(object newDepartment)
        {
            DepartmentName = newDepartment;
        }

        //event method
        protected virtual void OnMethodCalled(string e)
        {
            PrintCalledMethod?.Invoke(this, e);
        }

    }
    //Here  DepartmentName's datatype object used to run overloaded methods.
}
