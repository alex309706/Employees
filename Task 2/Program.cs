using Domain.Core;
using Domain.Interfaces;
using Infrastructure.Data;
using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //create context
            EmployeeContext context = new EmployeeContext();
            //Dependency Injection
            IEmployeeRepository EmployeeRepository = new EmployeeRepository(context);

            EmployeeInitializer initializer = new EmployeeInitializer();
            initializer.Initialize(EmployeeRepository);

            var employeesListSortByAge = EmployeeRepository.listAllSortByAge();
            Console.WriteLine("Collection,Sorted By Age:");
            foreach (var Employee in employeesListSortByAge)
            {
                PrintEmployee(Employee);
            }

            //hardcode , not good..maybe i should do Position as a model
            var position = "Receptionist";
            var employeesListByPosition = EmployeeRepository.listByPosition(position);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"List By Position {position} : ");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var Employee in employeesListByPosition)
            {
                PrintEmployee(Employee);
            }

            //let's pretend we chose 1990
            DateTime dateTimeToFindPeople = new DateTime(1990,1,1);
            var employeesBornAfterChosenDate = EmployeeRepository.findBornAfter(dateTimeToFindPeople);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"People born after {dateTimeToFindPeople.Year} :");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var employee in employeesBornAfterChosenDate)
            {
                PrintEmployee(employee);
            }


            //P.S. no time to do tests, have to do Task 1

        }
        static void PrintEmployee(Employee Employee)
        {
            Console.WriteLine($"ID: {Employee.Id} \n" +
                $"FirstName : {Employee.FirstName} \n" +
                $"Lastname : {Employee.LastName} \n" +
                $"Age: {Employee.Age} \n" +
                $"BirthDay : {Employee.Birthday.ToShortDateString()} \n" +
                $"StartDate: {Employee.StartDate.ToShortDateString()} \n" +
                $"Position: {Employee.Position} \n" +
                $"Email: {Employee.Email} \n");
        }
    }
}
