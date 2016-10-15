using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BookEditor_Model.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookEditor_Repository
{
    public abstract class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext
    {
        protected readonly DbContext _context;

        protected GenericRepository(DbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().First(x => x.Id == id);
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return _context.Set<TEntity>().FirstAsync(x => x.Id == id);
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async virtual Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity.Id;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void Delete(int id)
        {
            Delete(GetById(id));
        }

        public virtual void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual int Commit()
        {
            return _context.SaveChanges();
        }

        public virtual Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
