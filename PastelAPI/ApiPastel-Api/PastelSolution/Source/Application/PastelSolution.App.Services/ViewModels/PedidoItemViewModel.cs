using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.ViewModels
{
    public class PedidoItemViewModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public ProdutoViewModel Produto { get; set; }

    }
}
