﻿using PastelSolution.App.Services.Inputs;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.Interfaces.AppService
{
    public interface IPedidoAppService : IAppServiceBase<Pedido, PedidoViewModel, PedidoInput>
    {
    }
}
