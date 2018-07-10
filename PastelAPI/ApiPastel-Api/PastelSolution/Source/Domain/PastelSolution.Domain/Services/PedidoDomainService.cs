using PastelSolution.Domain.Interfaces.Repositories;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;

namespace PastelSolution.Domain.Services
{
    public class PedidoDomainService : DomainServiceBase<Pedido>, IPedidoDomainService
    {
        public PedidoDomainService(IPedidoRepository repositoryBase) : base(repositoryBase)
        {
        }
    }
}
