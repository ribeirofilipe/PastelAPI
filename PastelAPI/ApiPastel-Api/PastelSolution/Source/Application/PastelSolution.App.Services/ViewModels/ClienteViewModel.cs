using PastelSolution.Domain.Models;

namespace PastelSolution.App.Services.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Setor Setor { get; set; }

    }
}
