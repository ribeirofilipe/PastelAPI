using PastelSolution.Domain.Core.Models;
using System;
namespace PastelSolution.Domain.Models
{
    public class Pedido : Entity
    {
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }

        public Pedido(int clienteId, int quantidade, DateTime data, int produtoId)
        {
            ClienteId = clienteId;
            Quantidade = quantidade;
            Data = data;
            ProdutoId = produtoId;
        }

        public Pedido()
        {

        }
    }
}
