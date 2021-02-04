
using UKParliament.CodeTest.Utilities;
using System;
using System.Collections.Generic;

namespace UKParliament.CodeTest.Data
{
    public sealed class Person : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }

        private Person() { }

        public Person(string name,
                      string email,
                      DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception(ErrorMessages.InvalidModel);
            }

            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public void UpdateFields(string name,
                                 string email,
                                 DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(name))

            {
                throw new Exception(ErrorMessages.InvalidModel);
            }

            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}