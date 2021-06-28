using System;

namespace Domain.Core
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday{ get; set; }

        public string Position { get; set; }

        public DateTime StartDate { get; set; }
        public string Email { get; set; }

    }
}
