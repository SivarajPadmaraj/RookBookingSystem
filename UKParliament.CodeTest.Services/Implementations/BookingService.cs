using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Services
{
    public sealed class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _repository;

        public BookingService(IRepository<Booking> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Add a booking
        /// </summary>
        public async Task<ServiceResult> BookAsync(BookingModel model)
        {
            try
            {
                if (model.StartDate > model.EndDate)
                {
                    return ServiceResult.Error(ErrorMessages.InvalidDates, HttpStatusCode.BadRequest);
                }

                // Check the range of the given datetime
                if ((model.EndDate - model.StartDate).TotalHours > 1)
                {
                    return ServiceResult.Error(ErrorMessages.TimeRangeLimit, HttpStatusCode.BadRequest);
                }

                Booking booking = new Booking(model.PersonId, model.RoomId, model.StartDate, model.EndDate);
                _repository.Add(booking);
                await _repository.SaveChangesAsync();

                return ServiceResult.Success(booking.Id);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message, HttpStatusCode.InternalServerError);
            }
        }


        /// <summary>
        /// Remove the booking
        /// </summary>
        public async Task<ServiceResult> RemoveAsync(int id)
        {
            try
            {
                Booking booking = await _repository.Table.AsNoTracking()
                                                         .FirstOrDefaultAsync(e => e.Id == id);

                if (booking == null)
                {
                    return ServiceResult.Error(ErrorMessages.NotFound, HttpStatusCode.NotFound);
                }

                var local = _repository.Context.Set<Booking>().Local.FirstOrDefault(e => e.Id == id);

                if (local != null)
                {
                    _repository.Context.Entry(local).State = EntityState.Detached;
                }

                _repository.Remove(booking);
                await _repository.SaveChangesAsync();

                return ServiceResult.Success(booking.Id);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
