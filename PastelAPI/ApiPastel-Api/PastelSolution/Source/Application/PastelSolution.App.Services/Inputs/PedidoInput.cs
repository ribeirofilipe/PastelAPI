using System;

namespace PastelSolution.App.Services.Inputs
{
    public class PedidoInput
    {
        public int ClienteId { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public int ProdutoId { get; set; }
    }
}
