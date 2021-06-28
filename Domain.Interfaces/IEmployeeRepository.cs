using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void save(string FirstName, string LastName,int Age,DateTime Birthday, string Position, DateTime StartDate, string Email);
        void update(Guid ID,string FirstName, string LastName, int Age, DateTime Birthday, string Position, DateTime StartDate, string Email);
        void delete(Guid ID);

        Employee FindById(Guid ID);
        IEnumerable<Employee> listByPosition(string Position);
        IEnumerable<Employee> listAllSortByAge();
        IEnumerable<Employee> findBornAfter(DateTime date);
        //because we can have more than one person with such a FullName. I suppose that FullName = FirstName + LastName
        IEnumerable<Employee> FindByFullName(string FullName);
        IEnumerable<Employee> listStartDateThisYear();
    }
}
