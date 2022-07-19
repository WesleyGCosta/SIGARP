using Domain.IRepositories;
using Domain.Notifications.Interface;
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

        public IActionResult Create()
        {
            ViewBag.ListYears = LoadDropAno();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AtaViewModel ataViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ataViewModel);
            }

            var ata = AtaFactory.ToEntityAta(ataViewModel);

            await _createAta.Run(ata);

            TempData["Sucesso"] = "Cadastrado com Sucesso";

            return RedirectToAction("Index", "Home");
        }

        public IActionResult IncluirDetentora() => View();
        public IActionResult IncluirParticipante() => View();
    }
}
