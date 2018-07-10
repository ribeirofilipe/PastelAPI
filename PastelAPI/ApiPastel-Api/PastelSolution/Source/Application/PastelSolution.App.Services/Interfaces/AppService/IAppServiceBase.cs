using System.Collections.Generic;
using System.Threading.Tasks;

namespace PastelSolution.App.Services.Interfaces.AppService
{
    public interface IAppServiceBase<TEntity, TViewModel, TInput>
        where TViewModel : class
        where TInput : class
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TViewModel>> GetListAsync();
        Task<TInput> AddAsync(TInput entity);
        Task UpdateAsync(TViewModel entity, int id);
        Task DeleteAsync(TEntity entity, int id);

    }
}
