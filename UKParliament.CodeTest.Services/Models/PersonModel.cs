
using System;
using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Services
{
    public sealed class PersonModel : BaseModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}