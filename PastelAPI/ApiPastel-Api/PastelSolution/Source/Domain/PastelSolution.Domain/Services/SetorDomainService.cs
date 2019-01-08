using PastelSolution.Domain.Interfaces.Repositories;
using PastelSolution.Domain.Models;

namespace PastelSolution.Domain.Services
{
    public class SetorDomainService : DomainServiceBase<Setor>
    {
        public SetorDomainService(ISetorRepository repositoryBase) : base(repositoryBase)
        {
        }
    }
}
