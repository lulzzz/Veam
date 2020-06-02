using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Veam.Application.Core;
using Veam.Data;

namespace Veam.Infra.Data
{
    public class BaseReadModelRepository : IBaseReadModelRepository
    {
        protected readonly DataDbContext _dbContext;

        public BaseReadModelRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TReadModel> GetAll<TReadModel>(string sql, object parameters = null)
        {
            using (DbConnection connection = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                return  connection
                    .Query<TReadModel>(sql, parameters);
            }
        }

        public async Task<IEnumerable<TReadModel>> GetAllAsync<TReadModel>(string sql, object parameters = null)
        {
            using (DbConnection connection = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                return await connection
                    .QueryAsync<TReadModel>(sql, parameters);
            }
        }

        public TReadModel GetById<TReadModel>(string sql, object parameters = null)
        {
            using (DbConnection connection = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                return  connection
                    .QueryFirstOrDefault<TReadModel>(sql, parameters);
            }
        }

        public async Task<TReadModel> GetByIdAsync<TReadModel>(string sql, object parameters = null)
        {
            using (DbConnection connection = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                return await connection
                    .QueryFirstOrDefaultAsync<TReadModel>(sql, parameters);
            }
        }
    }
}
//_dbContext.Database.GetDbConnection()