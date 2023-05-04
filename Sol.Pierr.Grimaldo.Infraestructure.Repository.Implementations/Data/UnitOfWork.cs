using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sol.Pierr.Grimaldo.Infraestructure.Persistence;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces.Data;
using System;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Infraestructure.Repository.Implementations.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private bool _disposed;
        private IDbContextTransaction _transaction;
        public UnitOfWork(DataContext dataContext)
        {

        }

        public async Task BeginTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task<int> CompletedAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Entry(object obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public DbContext Get()
        {
            return _dbContext;
        }
        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangeTransaction()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    _dbContext.Dispose();
                }

            _disposed = true;
        }
    }
}
