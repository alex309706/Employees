using Domain.Core;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class EmployeeContext
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
