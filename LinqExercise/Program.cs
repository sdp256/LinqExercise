﻿using System;
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

            Console.WriteLine($"Sum of the numbers array: {numbers.Sum()}");
            Console.WriteLine($"Average of the numbers array: {numbers.Average()}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascendingNumbers = numbers.OrderBy(x => x);
            Console.WriteLine("Array in ascending order:");
            foreach (var number in ascendingNumbers)
            {
                Console.WriteLine(number);
            }
            var descendingNumbers = numbers.OrderByDescending(x => x);
            Console.WriteLine($"Array in descending order:");
            foreach (var number in descendingNumbers)
            {
                Console.WriteLine(number);
            }

            //Print to the console only the numbers greater than 6
            //var greaterThan6 = numbers.Where(x => x >= 6);
            Console.WriteLine("Numbers greater than 6:");
            foreach (var number in numbers)
            {
                if (number > 6)
                {
                    Console.WriteLine(number);
                }
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("only 4");
            var onlyFour = numbers.Where(x => x <= 3).OrderBy(x => x);
            foreach (var item in onlyFour)
            {
                Console.WriteLine(item);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("index 4 changed to age, and printed in descending order");
            numbers[4] = 30;
            var newFour = numbers.OrderByDescending(x => x);
            foreach (var item in newFour)
            {
                Console.WriteLine(item);
            }


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            Console.WriteLine("Employees' full names if they start with C or S, ordered by first name");
            var whereCOrS = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName);
            foreach (var employee in whereCOrS)
            {
                Console.WriteLine(employee.FullName);
            }


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees that are over 26 years old sorted by age and first name");
            var over26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var employee in over26)
            {
                Console.WriteLine($"{employee.FullName} {employee.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var experienceYears = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var experienceYearsSum = experienceYears.Sum(x => x.YearsOfExperience);
            Console.WriteLine(experienceYearsSum);

            //Add an employee to the end of the list without using employees.Add()
            
            employees = employees.Append(new Employee("Mr", "Bean", 66, 99)).ToList();

            foreach (var person in employees)
            {
                Console.WriteLine($"{person.FullName} {person.Age} {person.YearsOfExperience}");
            }
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
