using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AtaController : BaseController
    {
        private readonly CreateAta _createAta;
        private readonly SearchAta _searchAta;
        private readonly DeleteAta _deleteAta;
        public AtaController(IAtaRepository ataRepository, INotifier notifier) : base(notifier)
        {
            _createAta = new CreateAta(ataRepository);
            _searchAta = new SearchAta(ataRepository);
            _deleteAta = new DeleteAta(ataRepository);
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

        public IActionResult ManagementAta()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        public async Task<IActionResult> GetAta(int yearAta, int codeAta)
        {
            var ata = await _searchAta.GetAtaFullIncludeByYearAndCode(yearAta, codeAta);
            if (ata == null)
            {
                TempData["Warning"] = "Ata não Encontrada";
                return NotFound();
            }
                
            var ataViewModel = AtaFactory.ToViewModel(ata);
            return PartialView("_GeneralDetails", ataViewModel);
        }

        public async Task<IActionResult> GetListAtaByYear(int yearAta)
        {
            var atas = await _searchAta.GetListAtaByYear(yearAta);

            if (atas.Count.Equals(0))
                TempData["Warning"] = "Nenhuma Ata Encontrada";

            var listAtasViewModel = AtaFactory.ToListViewModel(atas);
            return PartialView("_ListAtas", listAtasViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int yearAta, int codeAta)
        {
            var ata = await _searchAta.GetAtaByYearAndCode(yearAta, codeAta);

            if(ata == null)
            {
                TempData["Warning"] = "Ata não encontrada";
                return NotFound();
            }

            await _deleteAta.Run(ata);
            TempData["Success"] = "Ata Excluído com Sucesso";

            return RedirectToAction("GetListAtaByYear", new {yearAta});
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
