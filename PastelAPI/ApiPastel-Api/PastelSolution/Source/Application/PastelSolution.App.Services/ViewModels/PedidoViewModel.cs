using System;

namespace PastelSolution.App.Services.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}
