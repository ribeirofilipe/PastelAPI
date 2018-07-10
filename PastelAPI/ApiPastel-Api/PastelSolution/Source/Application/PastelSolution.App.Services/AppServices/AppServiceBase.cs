using AutoMapper;
using PastelSolution.App.Services.Interfaces.AppService;
using PastelSolution.Domain.Core.Models;
using PastelSolution.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PastelSolution.App.Services.AppServices
{
    public abstract class AppServiceBase<TEntity, TViewModel, TInput> : IAppServiceBase<TEntity, TViewModel, TInput>
        where TEntity : Entity
        where TInput : class
        where TViewModel : class
    {
        private readonly IDomainServiceBase<TEntity> _domainService;

        protected  AppServiceBase(IDomainServiceBase<TEntity> domainService)
        {
            _domainService = domainService;
        }
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {

            var entity = await _domainService.GetByIdAsync(id);
            return Mapper.Map<TEntity>(entity);                      
        }

        public virtual async Task<List<TViewModel>> GetListAsync()
        {
            var entity = await _domainService.GetListAsync();
            return Mapper.Map<List<TViewModel>>(entity);
        }

        public virtual async Task<TInput> AddAsync(TInput input)
        {
            var entity = Mapper.Map<TEntity>(input);
            await _domainService.AddAsync(entity);

            return input;
        }
        public virtual async Task UpdateAsync(TViewModel viewModel, int id)
        {

            var entity = Mapper.Map<TEntity>(viewModel);
            entity.Id = id;
            await _domainService.UpdateAsync(entity, id);

        }

        public virtual async Task DeleteAsync(TEntity viewModel, int id)
        {
            var entity = Mapper.Map<TEntity>(viewModel);
            entity.Id = id;
            await _domainService.DeleteAsync(entity, id);
        }
    }
}
