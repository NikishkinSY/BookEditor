using BookEditor_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookEditor_Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Guid id);
        void Edit(TEntity entity);
    }
}
