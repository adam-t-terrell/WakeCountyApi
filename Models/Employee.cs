using System;

namespace WakeCountyApi.Models 
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }

        public Employee(string lastName, string firstName, string department)
        {
            LastName = lastName;
            FirstName = firstName;
            Department = department;
        }
    }
}
