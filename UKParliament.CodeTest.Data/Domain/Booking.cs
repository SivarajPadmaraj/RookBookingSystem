using UKParliament.CodeTest.Data.Domain.Base;
using System;

namespace UKParliament.CodeTest.Data.Domain
{
    public sealed class Booking : BaseEntity
    {
        public int PersonId { get; private set; }
        public int RoomId { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Person Person { get; private set; }
        public Room Room { get; private set; }

        private Booking() { }

        public Booking(int personId, int roomId, DateTime startDate, DateTime endDate)
        {
            PersonId = personId;
            RoomId = roomId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}