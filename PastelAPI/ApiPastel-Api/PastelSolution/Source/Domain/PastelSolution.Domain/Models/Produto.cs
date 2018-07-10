using PastelSolution.Domain.Core.Models;

namespace PastelSolution.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public Produto()
        {

        }
    }
}
