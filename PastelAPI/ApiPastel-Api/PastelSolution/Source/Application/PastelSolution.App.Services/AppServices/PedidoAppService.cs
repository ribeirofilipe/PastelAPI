using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PastelSolution.App.Services.Inputs;
using PastelSolution.App.Services.Interfaces.AppService;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.AppServices
{
    public sealed class PedidoAppService : AppServiceBase<Pedido, PedidoViewModel, PedidoInput>, IPedidoAppService
    {
        private readonly IPedidoDomainService _pedidoDomainService;
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IProdutoDomainService _produtoDomainService;


        public PedidoAppService(IPedidoDomainService pedidoDomainService, IClienteDomainService clienteDomainService, IProdutoDomainService produtoDomainService) : base(pedidoDomainService)
        {
            _pedidoDomainService = pedidoDomainService;
            _clienteDomainService = clienteDomainService;
            _produtoDomainService = produtoDomainService;
        }

        public async override Task<List<PedidoViewModel>> GetListAsync()
        {
            var getListPedidos = await _pedidoDomainService.GetListAsync();

            var pedidosVMList = new List<PedidoViewModel>();

          
            foreach (var pedido in getListPedidos)
            {
                var cliente = await _clienteDomainService.GetByIdAsync(pedido.ClienteId);
                var produto = await _produtoDomainService.GetByIdAsync(pedido.ProdutoId);

                var pedidoVM = Mapper.Map<PedidoViewModel>(pedido);

                pedidoVM.Cliente = Mapper.Map<ClienteViewModel>(cliente);
                pedidoVM.Produto = Mapper.Map<ProdutoViewModel>(produto);

                pedidosVMList.Add(pedidoVM);
            }

            return pedidosVMList;

        }
    }
}
