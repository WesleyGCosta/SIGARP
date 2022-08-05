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
        private readonly SearchAta _searchAta;
        public AtaController(IAtaRepository ataRepository, INotifier notifier) : base(notifier)
        {
            _createAta = new CreateAta(ataRepository);
            _searchAta = new SearchAta(ataRepository);
        }

        public IActionResult Create()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtaViewModel ataViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ataViewModel);
            }

            var ata = AtaFactory.ToEntityAta(ataViewModel);

            await _createAta.Run(ata);

            TempData["Success"] = "Cadastrado com Sucesso";

            return RedirectToAction("Create", "Item");
        }

        [HttpGet]
        public async Task<JsonResult> AutoCompleteNumberAta(int yearAta)
        {
            var ata = await _searchAta.GetAtaByYear(yearAta);
            if (ata == null)
                return Json(1);

            return Json(ata.CodigoAta + 1);
        }
    }
}
