﻿using BookEditor_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookEditor_Repository
{
    public interface IGenericRepository<TEntity> : IUnitOfWork where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        int Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Edit(TEntity entity);
    }
}
