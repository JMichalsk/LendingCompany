using System;
using LendingCompany.Domain.Model;

namespace LendingCompany.BL.Model
{
    public class Person : Entity
    {
        public Person(string firstName, string lastName, DateTime dateOfBirth, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Pesel = pesel;
        }

        private Person()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; }
        public string Pesel { get; }
    }
}
