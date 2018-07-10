using AutoMapper;
using PastelSolution.App.Services.Inputs;
using PastelSolution.App.Services.Interfaces.AppService;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PastelSolution.App.Services.AppServices
{
    public class PedidoItemAppService : AppServiceBase<PedidoItem, PedidoItemViewModel, PedidoItemInput>, IPedidoItemAppService
    {
        private readonly IPedidoItemDomainService _pedidoItemDomainService;
        private readonly IProdutoDomainService _produtoDomainService;

        public PedidoItemAppService(IPedidoItemDomainService pedidoItemDomainService, IProdutoDomainService produtoDomainService) : base(pedidoItemDomainService)
        {
            _pedidoItemDomainService = pedidoItemDomainService;
            _produtoDomainService = produtoDomainService;
        }

        //public async override Task<List<PedidoItemViewModel>> GetListAsync()
        //{
        //    var getListPedidoItem = await _pedidoItemDomainService.GetListAsync();

        //    var pedidosItensVMList = new List<PedidoItemViewModel>();

        //    foreach (var pedidoItem in getListPedidoItem)
        //    {
        //        var produto = _produtoDomainService.GetByIdAsync(pedidoItem.PedidoId);

        //        var pedidosItensVM = Mapper.Map<PedidoItemViewModel>(pedidoItem);

        //        pedidosItensVM = Mapper.Map<ProdutoViewModel>(produto);

        //        pedidosItensVMList.Add(pedidosItensVM);
        //    }

        //    return pedidosItensVMList;
        //}
    }
}
