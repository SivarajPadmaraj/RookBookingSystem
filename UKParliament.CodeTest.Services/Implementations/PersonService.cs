using UKParliament.CodeTest.Data;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UKParliament.CodeTest.Utilities;
namespace UKParliament.CodeTest.Services
{
    public sealed class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Add a person
        /// </summary>
        public async Task<ServiceResult> AddAsync(PersonModel model)
        {
            try
            {
                if (model == null
                    || string.IsNullOrWhiteSpace(model.Name)
                    || string.IsNullOrWhiteSpace(model.Email))
                {
                    return ServiceResult.Error(ErrorMessages.InvalidModel, HttpStatusCode.BadRequest);
                }

                Person person = new Person(model.Name, model.Email, model.DateOfBirth);
                _repository.Add(person);
                await _repository.SaveChangesAsync();

                return ServiceResult.Success(person.Id);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        ///  Get all with the given filtering parameters
        /// </summary>
        public async Task<ServiceResult> GetAllAsync(string name,  string email, DateTime? dateOfBirth)
        {
            try
            {
                // Creating predicate for filtering entities
                var predicate = PredicateBuilder.New<Person>(true);

                if (!string.IsNullOrWhiteSpace(name))
                {
                    predicate = predicate.And(e => e.Name.StartsWith(name));
                }

                if (!string.IsNullOrWhiteSpace(email))
                {
                    predicate = predicate.And(e => e.Email.StartsWith(email));
                }

                if (dateOfBirth.HasValue)
                {
                    predicate = predicate.And(e => e.DateOfBirth == dateOfBirth);
                }

                var query = _repository.Table.Where(predicate);

                List<PersonModel> result = await query.AsNoTracking()
                                                      .Select(e => new PersonModel()
                                                      {
                                                          Name = e.Name,
                                                          Email = e.Email,
                                                          DateOfBirth = e.DateOfBirth
                                                      })
                                                      .ToListAsync();

                return ServiceResult.Success(result);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get by id
        /// </summary>
        public async Task<ServiceResult> GetAsync(int id)
        {
            try
            {
                Person person = await _repository.Table.AsNoTracking()
                                                       .FirstOrDefaultAsync(e => e.Id == id);

                if (person == null)
                {
                    return ServiceResult.Error(ErrorMessages.NotFound, HttpStatusCode.NotFound);
                }

                var result = new PersonModel()
                             {
                                 //Id = person.Id,
                                 Name = person.Name,
                                 Email = person.Email,
                                 DateOfBirth = person.DateOfBirth
                             };

                return ServiceResult.Success(result);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Remove the person
        /// </summary>
        public async Task<ServiceResult> RemoveAsync(int id)
        {
            try
            {
                Person person = await _repository.Table.Include(e => e.Bookings)
                                                       .AsNoTracking()
                                                       .FirstOrDefaultAsync(e => e.Id == id);

                if (person == null)
                {
                    return ServiceResult.Error(ErrorMessages.NotFound, HttpStatusCode.NotFound);
                }

                var local = _repository.Context.Set<Person>().Local.FirstOrDefault(e => e.Id == id);

                if (local != null)
                {
                    _repository.Context.Entry(local).State = EntityState.Detached;
                }

                _repository.Remove(person);
                await _repository.SaveChangesAsync();

                return ServiceResult.Success(person.Id);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Update the person
        /// </summary>
        public async Task<ServiceResult> UpdateAsync(int id, PersonModel model)
        {
            try
            {
                Person person = await _repository.Table.AsNoTracking()
                                                       .FirstOrDefaultAsync(e => e.Id == id);

                if (person == null)
                {
                    return ServiceResult.Error(ErrorMessages.NotFound, HttpStatusCode.NotFound);
                }

                var local = _repository.Context.Set<Person>().Local.FirstOrDefault(e => e.Id == id);

                if (local != null)
                {
                    _repository.Context.Entry(local).State = EntityState.Detached;
                }

                person.UpdateFields(model.Name,  model.Email, person.DateOfBirth);
                _repository.Update(person);
                await _repository.SaveChangesAsync();

                return ServiceResult.Success(person.Id);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
