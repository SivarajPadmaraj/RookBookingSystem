using System;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Get by id
        /// </summary>
        Task<ServiceResult> GetAsync(int id);

        /// <summary>
        ///  Get all with the given filtering parameters
        /// </summary>
        Task<ServiceResult> GetAllAsync(string Name,  string email,  DateTime? dateOfBirth);

        /// <summary>
        /// Add a person
        /// </summary>
        Task<ServiceResult> AddAsync(PersonModel model);

        /// <summary>
        /// Update the person
        /// </summary>
        Task<ServiceResult> UpdateAsync(int id, PersonModel model);

        /// <summary>
        /// Remove the person
        /// </summary>
        Task<ServiceResult> RemoveAsync(int id);
    }
}