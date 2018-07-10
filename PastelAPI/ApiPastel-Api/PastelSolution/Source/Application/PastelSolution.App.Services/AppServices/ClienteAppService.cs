using AutoMapper;
using PastelSolution.App.Services.Interfaces.AppService;
using PastelSolution.App.Services.ViewModels;
using PastelSolution.Domain.Interfaces.Services;
using PastelSolution.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PastelSolution.App.Services.Inputs;

namespace PastelSolution.App.Services.AppServices
{
    public sealed class ClienteAppService : AppServiceBase<Cliente, ClienteViewModel, ClienteInput>, IClienteAppService
    {
        private readonly IClienteDomainService _clienteDomainService;
        
        public ClienteAppService(IClienteDomainService clienteDomainService) : base(clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }
    }
}
