using Domain.IRepositories;
using Historia.Atas;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AtaController : BaseController
    {
        private readonly CreateAta _createAta;
        public AtaController(IAtaRepository ataRepository, INotifier notifier) : base(notifier)
        {
            _createAta = new CreateAta(ataRepository);
        }

        public IActionResult Create() => View();

        public async Task<IActionResult> Create(AtaViewModel ataViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastrar", ataViewModel);
            }

            var ata = AtaFactory.ToEntityAta(ataViewModel);

            await _createAta.Run(ata);

            TempData["Sucesso"] = "Cadastrado com Sucesso";

            return View("Cadastrar");
        }

        public IActionResult IncluirDetentora() => View();
        public IActionResult IncluirParticipante() => View();
    }
}
