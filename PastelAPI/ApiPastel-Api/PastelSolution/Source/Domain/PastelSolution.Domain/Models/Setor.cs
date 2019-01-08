using PastelSolution.Domain.Core.Models;

namespace PastelSolution.Domain.Models
{
    public class Setor : Entity
    {
        public string Descricao { get; set; }

        public Setor(string descricao)
        {
            Descricao = descricao;
        }
    }
}
