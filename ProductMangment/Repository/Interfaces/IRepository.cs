using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductMangment
{
    public interface IRepository<TEntity, in TPk> where TEntity : class
    {
        List<TEntity> GetAll();
        List<TType> GetAll<TType>(Expression<Func<TEntity, TType>> select) where TType : class;
        List<TType> GetAll<TType>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TType>> select) where TType : class;
        List<TEntity> GetAllWithInclude(params string[] paths);
        List<TEntity> FindWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] paths);

        Task<List<TEntity>> GetAllWithIncludeAsync(params string[] paths);

        TEntity Get(TPk id);
        TEntity GetWithInclude(TPk id, params string[] paths);
        List<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] paths);
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void RemoveRange(List<TEntity> entities);
        void AddRange(List<TEntity> entities);
        EntityState GetState(TEntity entity);
        void SetState(TEntity entity, EntityState entityState);
        int GetCount();
        List<TEntity> GetAllWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] paths);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAllWithInclude(Expression<Func<TEntity, bool>> predicate, int? take, params String[] paths);
    }
}
