using PastelSolution.Domain.Interfaces.Repositories;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;

namespace PastelSolution.Domain.Services
{
    public class ProdutoDomainService : DomainServiceBase<Produto>, IProdutoDomainService
    {
        public ProdutoDomainService(IProdutoRepository repositoryBase) : base(repositoryBase)
        {
        }
    }
}
