using Domain.Interfaces;
using System;

namespace Task_2
{
    public class EmployeeInitializer
    {
        Random rnd = new Random();
        public void Initialize(IEmployeeRepository repository)
        {
            for (int i = 0; i < 10; i++)
            {
                Guid Id = Guid.NewGuid();
                string FirstName = GetRandomFirstName();
                string LastName = GetRandomLastName();
                int Age = rnd.Next(25, 60);
                string Position = GetRandomPosition();
                DateTime Birthday = GetRandomBirthDay(Age);
                DateTime StartDate = GetRandomDay();
                string Email = GetRandomEmail(FirstName, LastName);
                repository.save(FirstName,LastName,Age,Birthday,Position,StartDate,Email);
            }
        }
        public string GetRandomFirstName()
        {
            string[] FirstNames = { "Elizabeth", "Jake", "Howell", "Elmer", "Wynne" };
            int randomIndex = rnd.Next(0, FirstNames.Length - 1);
            return FirstNames[randomIndex];

        }
        public string GetRandomLastName()
        {
            string[] LastNames = { "Willis", "Pearson", "Austin", "Cole", "Fleming" };
            int randomIndex = rnd.Next(0, LastNames.Length - 1);
            return LastNames[randomIndex];
        }
        public string GetRandomPosition()
        {
            string[] Positions = { "Operations manager", "Office manager", "Receptionist", "Purchasing manager", "Marketing manager" };
            int randomIndex = rnd.Next(0, Positions.Length - 1);
            return Positions[randomIndex];
        }
        //according to firstName and lastName
        public string GetRandomEmail(string FirstName, string LastName)
        {
            string[] EmailServices = { "@mail.ru", "@yandex.ru", "@gmail.com", "@rambler.ru" };
            int randomIndex = rnd.Next(0, EmailServices.Length - 1);
            string chosenService = EmailServices[randomIndex];
            string randomEmail = LastName + FirstName + chosenService;
            return randomEmail;

        }
        DateTime GetRandomDay()
        {
            //let's pretend like our company was found on 01.01.2015
            DateTime DateOfFirstWorkingDay = new DateTime(2015, 1, 1);
            int rangeInDays = (DateTime.Today - DateOfFirstWorkingDay).Days;
            return DateOfFirstWorkingDay.AddDays(rnd.Next(rangeInDays));
        }

        DateTime GetRandomBirthDay(int age)
        {
            int CurrentYear = DateTime.Now.Year;
            int yearOfBirdth = CurrentYear - age;
            DateTime start = new DateTime(yearOfBirdth, 1, 1);
            //Let's pretend like we have 365 days in year.
            int rangeInDays = 365;
            return start.AddDays(rnd.Next(rangeInDays));
        }
    }
}
