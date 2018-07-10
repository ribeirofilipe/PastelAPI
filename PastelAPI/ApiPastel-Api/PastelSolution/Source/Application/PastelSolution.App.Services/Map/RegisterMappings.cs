using AutoMapper;
using PastelSolution.App.Services.Inputs;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.Map
{
    public class RegisterMappings
    {
        public static void Now()
        {
            Mapper.Initialize(cfg =>
           {
               cfg.CreateMap<Cliente, ClienteViewModel>();
               cfg.CreateMap<ClienteViewModel, Cliente>();

               cfg.CreateMap<Cliente, ClienteInput>();
               cfg.CreateMap<ClienteInput, Cliente>();

               cfg.CreateMap<Produto, ProdutoViewModel>();
               cfg.CreateMap<ProdutoViewModel, Produto>();

               cfg.CreateMap<Produto, ProdutoInput>();
               cfg.CreateMap<ProdutoInput, Produto>();

               cfg.CreateMap<Pedido, PedidoViewModel>();
               cfg.CreateMap<PedidoViewModel, Pedido>();

               cfg.CreateMap<Pedido, PedidoInput>();
               cfg.CreateMap<PedidoInput, Pedido>();

               cfg.CreateMap<PedidoItem, PedidoItemViewModel>();
               cfg.CreateMap<PedidoItemViewModel, PedidoItem>();

               cfg.CreateMap<PedidoItem, PedidoItemInput>();
               cfg.CreateMap<PedidoItemInput, PedidoItem>();

           });
        }
    }
}
