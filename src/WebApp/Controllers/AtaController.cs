using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp.Controllers
{
    [Authorize]
    public class AtaController : BaseController
    {
        private readonly CreateAta _createAta;
        private readonly SearchAta _searchAta;
        private readonly DeleteAta _deleteAta;
        private readonly UpdateAta _updateAta;
        public AtaController(IAtaRepository ataRepository, INotifier notifier) : base(notifier)
        {
            _createAta = new CreateAta(ataRepository);
            _searchAta = new SearchAta(ataRepository);
            _updateAta = new UpdateAta(ataRepository);
            _deleteAta = new DeleteAta(ataRepository);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        public async Task<JsonResult> GetAtasGraphicsByYears()
        {
            return Json(await _searchAta.GetAtasCountByYear(LoadDropYear()));
        }

        public async Task<JsonResult> GetAtasGraphicsByMonths()
        {
            return Json(await _searchAta.GetAtasCountByMonths());
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
        public IActionResult Management()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AtaViewModel ataViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Warining"] = "Erro na alteração da Ata";
                    return NotFound();
                }

                var item = AtaFactory.ToEntityAta(ataViewModel);
                await _updateAta.Edit(item);

                TempData["Success"] = "Item Alterado com Sucesso";

                return Ok();
            }
            catch (Exception ex)
            {
                TempData["Warining"] = $"Erro na alteração da Ata, imformaçõa do problema{ex.Message}";
                return Ok();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int yearAta, int codeAta)
        {
            var result = await _deleteAta.Run(yearAta, codeAta);

            if (!result)
            {
                TempData["Warning"] = "Ata não encontrada";
                return NotFound();
            }

            TempData["Success"] = "Ata Excluído com Sucesso";

            return RedirectToAction("GetListAtaByYear", new { yearAta });
        }

        [HttpGet]
        public async Task<IActionResult> GetAtaByYearAndCodeEdit(int yearAta, int codeAta)
        {
            var ata = await _searchAta.GetAtaFullIncludeByYearAndCode(yearAta, codeAta);
            if (ata == null)
            {
                TempData["Warning"] = "Ata não Encontrada";
                return NotFound();
            }

            ViewBag.ListYears = LoadDropYear();
            var ataViewModel = AtaFactory.ToViewModel(ata);
            return PartialView("_GeneralEdit", ataViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAtaByYearAndCode(int yearAta, int codeAta)
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

        [HttpGet]
        public async Task<IActionResult> GetListAtaByYear(int yearAta)
        {
            var atas = await _searchAta.GetListAtaByYear(yearAta);

            var listAtasViewModel = AtaFactory.ToListViewModel(atas);
            return PartialView("_ListAtas", listAtasViewModel);
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
