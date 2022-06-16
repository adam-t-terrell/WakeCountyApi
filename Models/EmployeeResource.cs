using System;

namespace WakeCountyApi.Models 
{
    public class EmployeeResource
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }

        public EmployeeResource(int id, string lastName, string firstName, string department, DateTime hireDate)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Department = department;
            HireDate = hireDate;
        }
    }
}
