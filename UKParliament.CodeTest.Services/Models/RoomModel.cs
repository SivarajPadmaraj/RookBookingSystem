

using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Services
{
    public sealed class RoomModel : BaseModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Name is required")]
        public string Name { get; set; }
    }
}
