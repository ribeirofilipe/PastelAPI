using PastelSolution.Domain.Core.Models;

namespace PastelSolution.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }

        public Cliente(string nome, int id)
        {
            Id = id;
            Nome = nome;
        }

        public Cliente()
        {

        }
    }
}
