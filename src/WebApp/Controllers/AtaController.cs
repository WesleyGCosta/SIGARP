using Domain.Entities;
using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

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

        #region HttpGet

        [HttpGet]
        public IActionResult Management()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        [HttpGet]
        public IActionResult Publish()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        [HttpGet]
        public IActionResult Rectify()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
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
        public IActionResult GenerateReport()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        #endregion

        #region HttPost
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
                TempData["Warning"] = $"Erro na alteração da Ata, imformaçõa do problema{ex.Message}";
                return Ok();
            }
        }



        [HttpPost]
        public async Task<IActionResult> Publish(int codeAta, int yearAta)
        {
            var ata = await _searchAta.GetAtaFullIncludeByYearAndCode(yearAta, codeAta);
            if (ata == null)
            {
                TempData["Warning"] = "Erro ao Publicar Ata";
                return NotFound();
            }

            if (!ValidationAta(ata))
            {
                return Ok("NotValidated");
            }

            await _updateAta.Publish(codeAta, yearAta);

            TempData["Success"] = "Ata Publicada com Sucesso";
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> Rectify(int codeAta, int yearAta)
        {
            var ata = await _searchAta.GetAtaByYearAndCodeAndPublish(yearAta, codeAta, true);
            if (ata == null)
            {
                TempData["Warning"] = "Erro ao Retificar Ata";
                return NotFound();
            }
            await _updateAta.Rectify(ata);

            TempData["Success"] = "Ata Retificada com Sucesso";
            return Ok();
        }
        #endregion

        #region "Médodo(s)"
        private bool ValidationAta(Ata ata)
        {
            var valid = true;

            if (ata.DataVencimentoAta < DateTime.Now)
            {
                TempData["Warning"] = "A Ata estar Vencida";
                return false;
            }

            if (!ata.Itens.Any())
            {
                TempData["Warning"] += "A Ata precisa ter pelo menos um Item Cadastrado";
                return false;
            }

            var itemDetentora = "";
            var itensQuantidade = "";

            foreach (var item in ata.Itens)
            {
                //valida se tem Detentora
                if (item.DetentoraItem == null)
                {
                    if (itemDetentora != "")
                    {
                        itemDetentora += " ," + item.NumeroItem.ToString();
                    }
                    else
                    {
                        itemDetentora = item.NumeroItem.ToString();
                    }
                }

                //valida sem a quantidade de itens estão sendo todas utilizadas
                if (item.QuantidadeDisponivel > 0)
                {
                    if (itensQuantidade != "")
                    {
                        itensQuantidade += " ," + item.NumeroItem.ToString();
                    }
                    else
                    {
                        itensQuantidade = item.NumeroItem.ToString();
                    }
                }
            }

            if (itemDetentora != "")
            {
                TempData["Warning"] += $"O(s) Item(s): {itemDetentora} não possuem detentora cadastrada</br>";
                valid = false;
            }

            if (itensQuantidade != "")
            {
                TempData["Warning"] += $"A quantidade do(s) Item(s): {itensQuantidade} precisa(m) ser utilizada(s) 100%!</br>";
                valid = false;
            }

            return valid;
        }
        #endregion

        #region "Consultas dinâmicas"
        [HttpGet]
        public async Task<JsonResult> GetAtasGraphicsByYears()
        {
            return Json(await _searchAta.GetAtasCountByYear(LoadDropYear()));
        }

        [HttpGet]
        public async Task<JsonResult> GetAtasGraphicsByMonths()
        {
            return Json(await _searchAta.GetAtasCountByMonths());
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
        public async Task<IActionResult> GetAtaPublish(int yearAta, int codeAta, bool publish)
        {
            var ata = await _searchAta.GetAtaPublish(yearAta, codeAta, publish);
            var ataViewModel = AtaFactory.ToViewModel(ata);
            return PartialView("_AtaDetailsPublish", ataViewModel);
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
        #endregion
    }
}
