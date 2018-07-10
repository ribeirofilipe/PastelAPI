using PastelSolution.Domain.Interfaces.Repositories;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;

namespace PastelSolution.Domain.Services
{
    public class ClienteDomainService : DomainServiceBase<Cliente>, IClienteDomainService
    {
        public ClienteDomainService(IClienteRepository repositoryBase) : base(repositoryBase)
        {
            
        }
    }
}
