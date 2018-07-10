using PastelSolution.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PastelSolution.Domain.Interfaces.Services
{
    public interface IDomainServiceBase<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetListAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity, int id);
        Task DeleteAsync(TEntity entity, int id);
    }
}
