using UKParliament.CodeTest.Services.Models.Base;
using System;

namespace UKParliament.CodeTest.Services.Models
{
    public sealed class BookingModel : BaseModel
    {
        public int PersonId { get; set; }
        public int RoomId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string PersonFullName { get; set; }
        public string RoomName { get; set; }
    }
}
