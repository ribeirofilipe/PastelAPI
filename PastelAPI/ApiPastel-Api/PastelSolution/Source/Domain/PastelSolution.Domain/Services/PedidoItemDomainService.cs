using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;
using PastelSolution.Domain.Interfaces.Repositories;

namespace PastelSolution.Domain.Services
{
    public class PedidoItemDomainService : DomainServiceBase<PedidoItem>, IPedidoItemDomainService
    {
        public PedidoItemDomainService(IPedidoItemRepository repositoryBase) : base(repositoryBase)
        {
        }
    }
}
