using PastelSolution.Domain.Interfaces.Repositories;
using PastelSolution.Domain.Models;

namespace PastelSolution.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
    }
}
