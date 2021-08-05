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
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
            Console.WriteLine("******************************");
            //Order numbers in ascending order and decsending order. Print each to console.
            var orderbyAcending = from num in numbers
                                  orderby num
                                  select num;

            foreach(int c in orderbyAcending)
                Console.WriteLine(c);

            Console.WriteLine("****************************");
            
            var orderbyDecending = from num in numbers
                                   orderby num descending
                                   select num;
            foreach(int c in orderbyDecending)
                Console.WriteLine(c);
            //Print to the console only the numbers greater than 6
            Console.WriteLine("*************************");
            var orderbyAcendingsix = from num in numbers
                                    where num>6
                                     orderby num
                                  select num;
            foreach (int c in orderbyAcendingsix)
                Console.WriteLine(c);



            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("***************************");
            var takethetopfour = numbers.OrderBy(x => x).Take(4);
            foreach(int c in takethetopfour)
                Console.WriteLine(c);



            //Change the value at index 4 to your age, then print the numbers in decsending order
            

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();
            Console.WriteLine("*************************************************************");
            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            var fullNameIfFirstIsCorS = employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S")).Select(x => x.FullName).OrderBy(x =>x);
            foreach(string c in fullNameIfFirstIsCorS)
                Console.WriteLine(c);
            //Order this in acesnding order by FirstName.
            Console.WriteLine("****************************************************");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var agefirstwithfirstname = employees.Where(x => x.Age > 26).Select(x => new { x.FirstName, x.Age }).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach(object c in agefirstwithfirstname)
                Console.WriteLine(c);
            Console.WriteLine("********************************************");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            var YOEsum= employees.Where(x => x.Age > 35 && x.YearsOfExperience < 10).Select(x => x.YearsOfExperience).Sum();
            var YOEaverage = employees.Where(x => x.Age > 35 && x.YearsOfExperience < 10).Select(x => x.YearsOfExperience).Average();
            Console.WriteLine(YOEsum);
            Console.WriteLine(YOEaverage);
            //if their YOE is less than or equal to 10 AND Age is greater than 35



            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Donte", "Inferno", 300, 200)).ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{ item.FirstName} : {item.LastName} : {item.FullName} : {item.Age} : {item.YearsOfExperience}");
            }
             

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
