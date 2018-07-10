﻿using PastelSolution.App.Services.Inputs;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.Interfaces.AppService
{
    public interface IProdutoAppService : IAppServiceBase<Produto, ProdutoViewModel, ProdutoInput>
    {
    }
}
