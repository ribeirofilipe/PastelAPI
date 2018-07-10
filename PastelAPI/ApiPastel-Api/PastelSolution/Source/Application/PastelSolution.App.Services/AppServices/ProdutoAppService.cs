using PastelSolution.App.Services.Inputs;
using PastelSolution.App.Services.Interfaces.AppService;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.AppServices
{
    public sealed class ProdutoAppService : AppServiceBase<Produto, ProdutoViewModel, ProdutoInput>, IProdutoAppService
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutoAppService(IProdutoDomainService produtoDomainService) : base(produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }
    }
}
