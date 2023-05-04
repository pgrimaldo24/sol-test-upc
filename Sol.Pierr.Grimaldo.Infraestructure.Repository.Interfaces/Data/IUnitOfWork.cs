using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces.Data
{
    public interface IUnitOfWork
    {
        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
        void Dispose(bool disposing); 
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbContext Get();
        Task BeginTransaction();
        Task SaveChangeTransaction();
        Task Rollback();
        void Entry(Object obj);
    }
}
