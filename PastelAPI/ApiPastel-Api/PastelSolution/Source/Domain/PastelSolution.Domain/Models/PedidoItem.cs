using PastelSolution.Domain.Core.Models;

namespace PastelSolution.Domain.Models
{
    public class PedidoItem : Entity
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        public PedidoItem(int pedidoId, int clienteId)
        {
            PedidoId = pedidoId;
            ProdutoId = clienteId;
        }

        public PedidoItem()
        {

        }
    }
}
