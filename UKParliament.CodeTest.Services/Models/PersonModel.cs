using UKParliament.CodeTest.Services.Models.Base;
using System;

namespace UKParliament.CodeTest.Services.Models
{
    public sealed class PersonModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}