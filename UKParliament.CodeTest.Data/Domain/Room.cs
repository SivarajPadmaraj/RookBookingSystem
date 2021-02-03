using UKParliament.CodeTest.Data.Domain.Base;

using System;
using System.Collections.Generic;

namespace UKParliament.CodeTest.Data.Domain
{
    public sealed class Room : BaseEntity
    {
        public string Name { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }

        private Room() { }

        public Room(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception(ErrorMessages.InvalidModel);
            }

            Name = name;
        }

        public void UpdateFields(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception(ErrorMessages.InvalidModel);
            }

            Name = name;
        }
    }
}