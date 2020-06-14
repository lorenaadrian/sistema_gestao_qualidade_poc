using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Shared
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class, IIdentityEntity
    {
        protected readonly IDbConnection dbConn;
        protected readonly IDbTransaction dbTransaction;

        protected virtual string InsertQuery { get; }
        protected virtual string InsertQueryReturnInserted { get; }
        protected virtual string UpdateByIdQuery { get; }
        protected virtual string DeleteByIdQuery { get; }
        protected virtual string SelectByIdQuery { get; }
        protected virtual string SelectAllQuery { get; }

        public RepositoryAsync(IDatabaseAccess databaseOptions)
        {
            dbConn = databaseOptions.GetDbConnection;
            dbConn.Open();
        }

        public RepositoryAsync(IDbConnection databaseConnection, IDbTransaction transaction = null)
        {
            dbConn = databaseConnection;
            if (dbConn.State != ConnectionState.Open)
                dbConn.Open();
            dbTransaction = transaction;
        }

        public void Dispose()
        {
            dbConn.Close();
            dbConn.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> AddAsync(T entity)
        {
            int x = await dbConn.ExecuteScalarAsync<int>(InsertQueryReturnInserted, entity, transaction: dbTransaction);
            return x;
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            return await dbConn.ExecuteAsync(InsertQuery, entities, transaction: dbTransaction);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbConn.QueryAsync<T>(SelectAllQuery, transaction: dbTransaction);
        }
        public async Task<T> GetByIdAsync(object id)
        {
            var entity = await dbConn.QueryAsync<T>(SelectByIdQuery, new { Id = id }, transaction: dbTransaction);
            return entity.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllByIdAsync(object id)
        {
            return await dbConn.QueryAsync<T>(SelectByIdQuery, new { Id = id }, transaction: dbTransaction);
        }
        public async Task<bool> RemoveAsync(object id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return false;

            return await RemoveAsync(entity) > 0 ? true : false;
        }
        public async Task<int> RemoveAsync(T obj)
        {
            return await dbConn.ExecuteAsync(DeleteByIdQuery, new { obj.id }, transaction: dbTransaction);
        }
        public async Task<int> RemoveRangeAsync(IEnumerable<T> entities)
        {
            return await dbConn.ExecuteAsync(DeleteByIdQuery, entities.Select(obj => new { obj.id }), transaction: dbTransaction);
        }

        public async Task<int> UpdateAsync(T obj)
        {
            return await dbConn.ExecuteAsync(UpdateByIdQuery, obj, transaction: dbTransaction);
        }
        public async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
        {
            return await dbConn.ExecuteAsync(UpdateByIdQuery, entities.Select(obj => obj), transaction: dbTransaction);
        }
    }
}
