using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var average = numbers.Average();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {average}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(num => num);
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Ascending Order");

            foreach (var number in ascending)
            {
                Console.WriteLine(number);
            }

            var descending = numbers.OrderByDescending(num => num);
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Descending Order");

            foreach (int number in descending)
            {
                Console.WriteLine(number);
            }


            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6).ToList();

            Console.WriteLine("Greater than six:");

            greaterThanSix.ForEach(number => Console.WriteLine(number));

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("First four ascending:");

            foreach (var num in ascending.Take(4))
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 33;

            Console.WriteLine("Value change with my age:");

            foreach(var num in descending)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var firstNameFilter = 
                employees.Where(employee => employee.FirstName[0] == 'C' || employee.FirstName.StartsWith('S'))
                .OrderBy(employee => employee.FirstName);

            Console.WriteLine("Employees with first name that start with C or S:");
            foreach(var employee in firstNameFilter)
            {
                Console.WriteLine(employee.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = 
                employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age)
                .ThenBy(employee => employee.FirstName);

            Console.WriteLine("Employees over the age 26");
            foreach(var employee in overTwentySix)
            {
                Console.WriteLine($"Age:{employee.Age} Fullname:{employee.FullName}");
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var years = employees.Where(employee => employee.YearsOfExperience >= 10 && employee.Age < 35);
            var sumOfYOE = years.Sum(employee => employee.YearsOfExperience);
            var avg = years.Average(employee => employee.YearsOfExperience);

            Console.WriteLine("Sum and Average of employees years of experience");
            
            Console.WriteLine($"Sum: {sumOfYOE} Average: {avg}");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jesse", "Mascorro", 33, 1)).ToList();
            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee.FullName} {employee.Age} {employee.YearsOfExperience}");
            }
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
