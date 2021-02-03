
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Services
{
    public interface IBookingService
    {
        /// <summary>
        /// Add a booking
        /// </summary>
        Task<ServiceResult> BookAsync(BookingRequestModel model);

        /// <summary>
        /// Remove the booking
        /// </summary>
        Task<ServiceResult> RemoveAsync(int id);
    }
}
