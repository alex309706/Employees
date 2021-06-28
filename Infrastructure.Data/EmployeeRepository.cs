using Domain.Core;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext store;
        public EmployeeRepository(EmployeeContext ctx)
        {
            store = ctx;
        }
        public void delete(Guid ID)
        {
            Employee employeeToDelete = store.Employees.First(emp => emp.Id == ID);
            if (employeeToDelete != null)
            {
                store.Employees.Remove(employeeToDelete);
            }
        }

        public IEnumerable<Employee> findBornAfter(DateTime date)
        {
            return store.Employees.Where(employee=> employee.Birthday > date);
        }

        public IEnumerable<Employee> FindByFullName(string FullName)
        {
            return store.Employees.Where(employee => FullName.Contains(employee.FirstName)&& FullName.Contains(employee.LastName)) ;
        }

        //throws exception if we have no object with input ID
        public Employee FindById(Guid ID)
        {
            Employee employeeToReturn = store.Employees.FirstOrDefault(employee => employee.Id == ID);
            if (employeeToReturn != null)
            {
                return employeeToReturn;
            }
            else 
            {
                throw new NullReferenceException($"There is no object with id = {ID}");
            }
        }

        public IEnumerable<Employee> listAllSortByAge()
        {
            return store.Employees.OrderBy(employee=> employee.Age);
        }

        public IEnumerable<Employee> listByPosition(string Position)
        {
            return store.Employees.Where(employee => employee.Position==Position);
        }

        public IEnumerable<Employee> listStartDateThisYear()
        {
            return store.Employees.Where(employee=> employee.StartDate.Year == DateTime.Now.Year);
        }

        public void save(string FirstName, string LastName, int Age, DateTime Birthday, string Position, DateTime StartDate, string Email)
        {
            Employee newEmployee = new Employee 
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Birthday = Birthday,
                Position= Position,
                StartDate= StartDate,
                Email = Email
            };
            store.Employees.Add(newEmployee);
        }
        //throws NullReferenceException
        public void update(Guid ID, string FirstName, string LastName, int Age, DateTime Birthday, string Position, DateTime StartDate, string Email)
        {
            Employee employeeToUpdate = store.Employees.FirstOrDefault(employee => employee.Id == ID);

            if (employeeToUpdate!=null)
            {
                employeeToUpdate.FirstName = FirstName;
                employeeToUpdate.LastName = LastName;
                employeeToUpdate.Age = Age;
                employeeToUpdate.Birthday = Birthday;
                employeeToUpdate.Position = Position;
                employeeToUpdate.StartDate = StartDate;
                employeeToUpdate.Email = Email;
            }
            else
            {
                throw new NullReferenceException("We Can't update the Object . There is no object with such an ID.");
            }
        }

    }
}
