﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces;

namespace Sol.Pierr.Grimaldo.Infraestructure.Repository.Implementations
{
    public abstract class BaseRepository<TContext, T> : IBaseRepository<T> where T : class where TContext : DbContext
    {
        private DbSet<T> table = null;
        private readonly TContext Context;

        public BaseRepository(TContext context)
        {
            Context = context;
            table = context.Set<T>();
        }

        public async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate) => await table.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int id) => await table.FindAsync(id);

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Update(T entity, bool activarDeteccion = false)
        {
            table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
         !trackChanges ?
              Context.Set<T>()
             .AsNoTracking() :
              Context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
           !trackChanges ?
                Context.Set<T>()
               .Where(expression)
               .AsNoTracking() :
                Context.Set<T>()
               .Where(expression);
    }
}
