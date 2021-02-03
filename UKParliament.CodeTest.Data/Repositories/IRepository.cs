
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<long> SaveChangesAsync();
        DbSet<T> Table { get; }
        RoomBookingsContext Context { get; }
    }
}
