﻿using System.Linq.Expressions;

namespace CatchDotNet.Core.Data
{
    public interface IRepository
    {
       
    }

    public interface IRepository<TEntity> : IRepository
    {
        #region Commands
        /// <summary>
        /// Create a row
        /// </summary>
        /// <param name="input"></param>
        void Insert(TEntity input);
        /// <summary>
        /// Create a row as async
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task InsertAsync(TEntity input, CancellationToken cancellationToken=default);

        /// <summary>
        /// Delete a row
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //Task DeleteAsync(TEntity input);

        

        /// <summary>
        /// Update data
        /// </summary>        
        /// <param name="input"></param>
        void Update(TEntity input);

        /// <summary>
        /// Delete a data
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
        /// <summary>
        /// Remove data from database.
        /// </summary>
        /// <param name="id"></param>
        void HardDelete(Guid id);
        #endregion

        #region Queries

        /// <summary>
        /// Get all data as quaryable
        /// </summary>
        /// <returns></returns>
        //Task<IQueryable<TEntity>> GetAllAsync();
        /// <summary>
        /// Get all datas 
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// Find a data using expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity? Find(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Find a data  as async
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken=default);
        /// <summary>
        /// Get data list
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetList();
        /// <summary>
        /// Get data list using expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Get data list as async
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Get data list using expression as async 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken=default);
        /// <summary>
        /// Get all list with includes
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes );
        /// <summary>
        /// Get all list with includes
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        ///
        TEntity? Get(Guid id);
        /// <summary>
        /// Get async 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken=default);

       
 

        #endregion
    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity>
    {
        

        /// <summary>
        /// Get a data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TKey id);
        /// <summary>
        /// Get a data as async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken=default);
        /// <summary>
        /// Delete a row
        /// </summary>
        /// <param name="input"></param>
        void Delete(TEntity input);
        /// <summary>
        /// Delete a data with id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(TKey id);
        /// <summary>
        /// Remove data from database.
        /// </summary>
        /// <param name="id"></param>
        void HardDelete(TKey id);

    }


}
