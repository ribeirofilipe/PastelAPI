using PastelSolution.App.Services.Inputs;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.AppServices
{
    public class SetorAppService : AppServiceBase<Setor, SetorViewModel, SetorInput>
    {
        private readonly ISetorDomainService _setorDomainService;

        public SetorAppService(ISetorDomainService setorDomainService) : base(setorDomainService)
        {
            _setorDomainService = setorDomainService;
        }
    }
}
