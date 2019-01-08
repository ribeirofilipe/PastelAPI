using PastelSolution.Domain.Core.Models;

namespace PastelSolution.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public int IdSetor { get; set; }

        public Cliente(string nome, int idSetor)
        {
            Nome = nome;
            IdSetor = idSetor;
        }

        public Cliente()
        {

        }
    }
}
