using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Persistencia
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DataContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _db.Update(entity);
            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            _db.Remove(entity);
            await SaveChanges();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByPrimaryKey(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
