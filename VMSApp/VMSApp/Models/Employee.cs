﻿namespace VMSApp.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int Empno { get; set; }
        public string Role { get; set; }
        public Employee()
        {
        }

        public Employee(int id, string firstName, string email, string lastName, string password, string status)
        {
            Id = id;
            FirstName = firstName;
            Email = email;
            LastName = lastName;
            Password = password;
            Status = status;
        }
    }
}
