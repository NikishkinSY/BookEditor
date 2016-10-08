using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BookEditor_Model.Context;
using BookEditor_Model.Entities;

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
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return query;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().First(x => x.Id == id);
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);
            return query;
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

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
}
