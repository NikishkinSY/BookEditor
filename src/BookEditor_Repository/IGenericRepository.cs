using BookEditor_Model.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookEditor_Repository
{
    public interface IGenericRepository<TEntity> : IUnitOfWork where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        int Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Edit(TEntity entity);
    }
}
