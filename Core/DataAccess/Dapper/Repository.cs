using CaseProject.Core.DataAccess.Dapper.Context;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.DataAccess.Dapper
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDbConnection DbConnection { get; private set; }
        private readonly DatabaseSettings _dbSettings;

        public Repository(DatabaseSettings dbSettings)
        {
            _dbSettings = dbSettings;
            DbConnection = new DbContext().SetStrategy()
                .GetDbContext(_dbSettings.ConnectionString);
        }

        public async Task<List<TEntity>> FindAllAsync()

        {
            DbConnection.Open();

            try
            {
                var results = await DbConnection
                    .GetAllAsync<TEntity>();

                return results
                    .ToList();
            }
            finally { DbConnection.Close(); }
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            DbConnection.Open();

            try
            {
                return await DbConnection
                    .GetAsync<TEntity>(id);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            DbConnection.Open();
            try
            {
                var inserted = await DbConnection
                .InsertAsync<TEntity>(entity);

                return inserted == 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            DbConnection.Open();

            try
            {
                var entity = await DbConnection
                    .GetAsync<TEntity>(id);

                if (entity == null)
                    return false;

                return await DbConnection
                    .DeleteAsync<TEntity>(entity);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            DbConnection.Open();

            try
            {
                return await DbConnection
                    .UpdateAsync<TEntity>(entity);
            }
            finally { DbConnection.Close(); }
        }

        //public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        //{
        //    DbConnection.Open();
        //    try
        //    {
        //        var data = await DbConnection.GetAllAsync<TEntity>();
        //        var results2 = data.AsList();
        //        var results = data.AsQueryable().Where(filter).ToList();

        //        return filter == null
        //            ? results2 //Filtre null'sa bu çalışır
        //            : results;//Filtre null değilse bu çalışır

        //    }
        //    finally { DbConnection.Close(); }
        //}
    }
}
