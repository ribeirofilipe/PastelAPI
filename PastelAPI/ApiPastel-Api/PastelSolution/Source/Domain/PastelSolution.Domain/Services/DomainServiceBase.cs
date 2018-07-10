using PastelSolution.Domain.Core.Models;
using PastelSolution.Domain.Interfaces.Services;
using System.Threading.Tasks;
using PastelSolution.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace PastelSolution.Domain.Services
{
    public abstract class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity>
        where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        protected DomainServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _repositoryBase.GetListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repositoryBase.AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity, int id)
        {
            await _repositoryBase.DeleteAsync(entity);
        }
        public async Task UpdateAsync(TEntity entity, int id)
        {
            await _repositoryBase.UpdateAsync(entity, id);
        }        
    }
}
