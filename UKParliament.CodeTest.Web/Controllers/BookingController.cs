using UKParliament.CodeTest.Services.Interfaces;
using UKParliament.CodeTest.Services.Models;
using UKParliament.CodeTest.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Web.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController :  BaseController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {

            _bookingService = bookingService;
        }
        [HttpPost("bookings")]
        public async Task<ObjectResult> BookAsync([FromBody] BookingRequestModel model)
        {
            var result = await _bookingService.BookAsync(model);

            return BaseResult(result);
        }

        [HttpDelete("bookings/{id:int}")]
        public async Task<ObjectResult> RemoveBookingAsync([FromRoute] int id)
        {
            var result = await _bookingService.RemoveAsync(id);

            return BaseResult(result);
        }

    }
}
