using System.Threading.Tasks;
using PastelSolution.Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using PastelSolution.Domain.Core.Models;
using System.Linq;
using System.Collections.Generic;
using DapperExtensions;

namespace PastelSolution.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : Entity
    {
        protected const string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=PastelAPI;Integrated Security=True";

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.GetAsync<TEntity>(id);
            }
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return ((await connection.GetListAsync<TEntity>()).ToList());
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                await connection.InsertAsync(entity);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                await connection.DeleteAsync(entity);

            }
        }

        public async Task UpdateAsync(TEntity entity, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                await connection.UpdateAsync(entity);
            }
        }

    }
}
