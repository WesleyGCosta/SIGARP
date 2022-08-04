using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Historia.Detentoras;
using Historia.DetentorasItem;
using Historia.Itens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ItemController : BaseController
    {
        private readonly SearchAta _searchAta;
        private readonly SearchItem _searchItem;
        private readonly SearchDetentora _searchDetentora;
        private readonly CreateItem _createItem;
        private readonly CreateDetentoraItem _createDetentoraItem;
        public ItemController(
            IAtaRepository ataRepository,
            IItemRepository itemRepository,
            IDetentoraRepository detentoraRepository,
            IDetentoraItemRepository detentoraItemRepository,
            INotifier notifier) : base(notifier)
        {
            _searchAta = new SearchAta(ataRepository);
            _searchItem = new SearchItem(itemRepository);
            _searchDetentora = new SearchDetentora(detentoraRepository);
            _createItem = new CreateItem(itemRepository);
            _createDetentoraItem = new CreateDetentoraItem(detentoraItemRepository);
        }

        public IActionResult Create()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListYears = LoadDropYear();
                ViewBag.ListCodeAta = new SelectList(await _searchAta.GetListCodeByYear(itemViewModel.AnoAta));
                return View(itemViewModel);
            }

            var item = ItemFactory.ToEntityItem(itemViewModel);

            await _createItem.Run(item);

            TempData["Success"] = "Item Cadastrado com Sucesso";

            return RedirectToAction("IncludeDetentora");
        }

        public async Task<IActionResult> IncludeDetentora()
        {
            var detentoras = await _searchDetentora.GetAll();

            ViewBag.ListYears = LoadDropYear();
            ViewBag.ListDetentora = new SelectList(detentoras, "Id", "RazaoSocial");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncludeDetentora(ItemDetentoraViewModel itemDetentoraViewModel)
        {
            if (!ModelState.IsValid)
            {
                await FillViewBags(itemDetentoraViewModel.AnoAta, itemDetentoraViewModel.CodigoAta);
                return View(itemDetentoraViewModel);
            }

            var itemDetentora = ItemDetentoraFactory.ToListEntityDetentoraItem(itemDetentoraViewModel);

            await _createDetentoraItem.Run(itemDetentora);

            TempData["Success"] = "Detentora Incluído com Sucesso";
           
            return RedirectToAction("Index", "Home");
        }

        public IActionResult IncludeParticipante() => View();


        //Consultas dinâmica
        public async Task<JsonResult> AutoCompleteListCodeAta(int yearAta)
        {
            var listCodeAta = await _searchAta.GetListCodeByYear(yearAta);

            return Json(listCodeAta);
        }

        public async Task<JsonResult> AutoCompleteListCodeItem(int yearAta, int codeAta)
        {
            var listItem = await _searchItem.GetListItemByCodeAtaAndYearAta(yearAta, codeAta);

            return Json(listItem);
        }

        public async Task<JsonResult> AutoCompleteCodeItem(int yearAta, int codeAta)
        {
            var lastItem = await _searchItem.GetLastItemByCodeAtaAndYearAta(yearAta, codeAta);

            if (lastItem == null)
                return Json(1);

            return Json(lastItem.NumeroItem + 1);
        }

        public async Task<IActionResult> GetListDetentoraRegistered(int yearAta, int codeAta)
        {
            var itens = await _searchItem.GetListItemWithDetentora(yearAta, codeAta);

            var itemViewModel = ItemFactory.ToListItemViewModel(itens);


            return PartialView("_listDetentoraRegistered", itemViewModel);
        }

        public async Task FillViewBags(int yearAta, int codeAta)
        {
            ViewBag.ListYears = LoadDropYear();
            ViewBag.ListCodeItem = new SelectList(await _searchItem.GetListItemByCodeAtaAndYearAta(yearAta, codeAta), "Id", "Exibicao");
            ViewBag.ListCodeAta = new SelectList(await _searchAta.GetListCodeByYear(yearAta));
            ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial");
        }

    }
}
