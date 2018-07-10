using PastelSolution.App.Services.AppServices;
using PastelSolution.App.Services.Interfaces.AppService;
using PastelSolution.Domain.Interfaces.Repositories;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Services;
using PastelSolution.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace PastelSolution.Infra.IoC.Bootstrapper
{
    public static class IoCManager
    {
        public static Container Inject()
        {
            var container = new Container
            {
                Options =
                {
                    DefaultScopedLifestyle = new AsyncScopedLifestyle()
                }
            };

            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IClienteDomainService, ClienteDomainService>();
            container.Register<IClienteAppService, ClienteAppService>();

            container.Register<IProdutoRepository, ProdutoRepository>();
            container.Register<IProdutoDomainService, ProdutoDomainService>();
            container.Register<IProdutoAppService, ProdutoAppService>();

            container.Register<IPedidoRepository, PedidoRepository>();
            container.Register<IPedidoDomainService, PedidoDomainService>();
            container.Register<IPedidoAppService, PedidoAppService>();

            container.Register<IPedidoItemRepository, PedidoItemRepository>();
            container.Register<IPedidoItemDomainService, PedidoItemDomainService>();
            container.Register<IPedidoItemAppService, PedidoItemAppService>();

            return container;

        }
    }
}
