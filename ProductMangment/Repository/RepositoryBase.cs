
using Microsoft.EntityFrameworkCore;
using ProductMangment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductMangment
{
    public abstract class RepositoryBase<TEntity, TPk> : IRepository<TEntity, TPk> where TEntity : class
    {
        public readonly ProductContext _dbContext;

        public RepositoryBase(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where<TEntity>(predicate).ToList();

        }

        public TEntity Get(TPk id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Get data table with select specific columns and predicate
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="predicate">select data with custome predicate</param>
        /// <param name="select"></param>
        /// <returns></returns>
        public List<TType> GetAll<TType>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TType>> select) where TType : class
        {
            return _dbContext.Set<TEntity>().Where(predicate).Select(select).ToList();
        }
        /// <summary>
        /// Get data table with select specific columns
        /// </summary>
        /// <typeparam name="TType">return anynomous type</typeparam>
        /// <param name="select">selected columns</param>
        /// <returns></returns>
        public List<TType> GetAll<TType>(Expression<Func<TEntity, TType>> select) where TType : class
        {
            return _dbContext.Set<TEntity>().Select(select).ToList();
        }
        public List<TEntity> GetAllWithInclude(params String[] paths)
        {
            IQueryable<TEntity> list = _dbContext.Set<TEntity>();
            for (int i = 0; i < paths.Length; i++)
            {
                list = list.Include(paths[i]);
            }
            return list.ToList();
        }

        public List<TEntity> GetAllWithInclude(Expression<Func<TEntity, bool>> predicate, int? take, params String[] paths)
        {
            IQueryable<TEntity> list = _dbContext.Set<TEntity>().Where(predicate).Take(take ?? int.MaxValue);
            for (int i = 0; i < paths.Length; i++)
            {
                list = list.Include(paths[i]);
            }
            return list.ToList();
        }

        public List<TEntity> GetAllWithInclude(Expression<Func<TEntity, bool>> predicate, params String[] paths)
        {

            IQueryable<TEntity> list = _dbContext.Set<TEntity>().Where(predicate);
            for (int i = 0; i < paths.Length; i++)
            {
                list = list.Include(paths[i]);
            }
            return list.ToList();
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }
        public void AddRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public EntityState GetState(TEntity entity)
        {
            return _dbContext.Entry<TEntity>(entity).State;
        }



        public void SetState(TEntity entity, EntityState entityState)
        {
            _dbContext.Entry<TEntity>(entity).State = entityState;
        }

        public int GetCount()
        {
            return _dbContext.Set<TEntity>().Count();
        }

        public void Update(TEntity entity)
        {
            SetState(entity, EntityState.Modified);
        }

        public List<TEntity> FindWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] paths)
        {
            throw new NotImplementedException();
        }

        public TEntity GetWithInclude(TPk id, params string[] paths)
        {

            IQueryable<TEntity> entity = null;
            for (int i = 0; i < paths.Length; i++)
            {
                entity = _dbContext.Set<TEntity>().Include(paths[i]);
            }

            // var x= (entity as DbSet<TEntity>).Find(id);
            return null;
        }


        public List<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] paths)
        {
            IQueryable<TEntity> list = _dbContext.Set<TEntity>().Where(predicate);
            for (int i = 0; i < paths.Length; i++)
            {
                list = list.Include(paths[i]);
            }
            return list.ToList();
        }


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public async Task<List<TEntity>> GetAllWithIncludeAsync(params string[] paths)
        {
            IQueryable<TEntity> list = _dbContext.Set<TEntity>();
            for (int i = 0; i < paths.Length; i++)
            {
                list = list.Include(paths[i]);
            }
            return list.ToList();
        }
      
    }

}

