using UKParliament.CodeTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Web
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ModelValidationAttribute))]
    public class BookingsController : BaseController
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {

            _bookingService = bookingService;
        }
        [HttpPost]
        public async Task<ObjectResult> BookAsync([FromBody] BookingModel model)
        {
            var result = await _bookingService.BookAsync(model);

            return BaseResult(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ObjectResult> RemoveBookingAsync([FromRoute] int id)
        {
            var result = await _bookingService.RemoveAsync(id);

            return BaseResult(result);
        }

    }
}
