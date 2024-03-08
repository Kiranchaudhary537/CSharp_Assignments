using System;
using System.Linq;
using System.Collections.Generic;



public class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public int Age { get; set; }
}

public class Salary
{
    public int EmployeeID { get; set; }
    public int Amount { get; set; }
    public SalaryType Type { get; set; }
}

public enum SalaryType
{
    Monthly,
    Performance,
    Bonus
}

public class Program
{
    IList<Employee> employeeList;
    IList<Salary> salaryList;

    public Program()
    {
        employeeList = new List<Employee>() {
            new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
            new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
            new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
            new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
            new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
            new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
            new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
        };

        salaryList = new List<Salary>() {
            new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
        };
    }

    public static void Main()
    {
        Program program = new Program();

        program.Task1();

        program.Task2();

        program.Task3();
    }

    public void Task1()
    {
        var totalSalaryByEmployee = from employee in employeeList
                                    join salary in salaryList on employee.EmployeeID equals salary.EmployeeID
                                    group salary by new { employee.EmployeeFirstName, employee.EmployeeLastName } into g
                                    select new
                                    {
                                        FullName = $"{g.Key.EmployeeFirstName} {g.Key.EmployeeLastName}",
                                        TotalSalary = g.Sum(s => s.Amount)
                                    };

        Console.WriteLine("Answer 1. \n Total Salary of all employees with their names (ascending order of salary):");
        foreach (var item in totalSalaryByEmployee.OrderBy(x => x.TotalSalary))
        {
            Console.WriteLine($"{item.FullName}: {item.TotalSalary}");
        }
        Console.WriteLine();
    }

    public void Task2()
    {
        var secondOldestEmployee = (from employee in employeeList
                                    orderby employee.Age descending
                                    select employee).Skip(1).FirstOrDefault();

        if (secondOldestEmployee != null)
        {
            var employeeSalary = salaryList.Where(s => s.EmployeeID == secondOldestEmployee.EmployeeID)
                                           .Sum(s => s.Amount);
            Console.WriteLine($"Answer 2. \n Employee details of the 2nd oldest employee:");
            Console.WriteLine($"ID: {secondOldestEmployee.EmployeeID}, Name: {secondOldestEmployee.EmployeeFirstName} {secondOldestEmployee.EmployeeLastName}, Age: {secondOldestEmployee.Age}");
            Console.WriteLine($"Total Monthly Salary: {employeeSalary}");
        }
        else
        {
            Console.WriteLine("No second oldest employee found.");
        }
        Console.WriteLine();
    }

    public void Task3()
    {
        var meanSalaries = from employee in employeeList
                           join salary in salaryList on employee.EmployeeID equals salary.EmployeeID
                           where employee.Age > 30
                           group salary by new { salary.Type } into g
                           select new
                           {
                               SalaryType = g.Key.Type,
                               MeanSalary = g.Average(s => s.Amount)
                           };

        Console.WriteLine("Answer 3. \n Mean salaries of Monthly, Performance, and Bonus for employees above 30 years old:");
        foreach (var item in meanSalaries)
        {
            Console.WriteLine($"{item.SalaryType}: {item.MeanSalary}");
        }
        Console.WriteLine();
    }
}
