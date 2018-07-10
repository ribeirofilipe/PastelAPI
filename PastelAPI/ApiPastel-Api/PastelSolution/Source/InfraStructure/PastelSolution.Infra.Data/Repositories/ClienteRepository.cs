using Dapper;
using PastelSolution.Domain.Interfaces.Repositories;
using PastelSolution.Domain.Models;
using System.Threading.Tasks;

namespace PastelSolution.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
    }
}
