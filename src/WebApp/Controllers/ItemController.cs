using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Historia.Detentoras;
using Historia.DetentorasItem;
using Historia.Itens;
using Historia.UnidadesAdministrativas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
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

        public async Task<IActionResult> Create()
        {
            ViewBag.ListYears = LoadDropYear();
            ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid)
            {
                await FillViewBags(itemViewModel.AnoAta);
                return View(itemViewModel);
            }

            var existe = await _searchItem.GetItemByCodeAtaAndYearAta(itemViewModel.AnoAta, itemViewModel.CodigoAta, itemViewModel.CodigoItem);
            if(existe != null)
            {
                await FillViewBags(itemViewModel.AnoAta);
                TempData["Warning"] = $"Item {itemViewModel.CodigoItem} já existe na Ata {itemViewModel.CodigoAta}/{itemViewModel.AnoAta}";
                return View(itemViewModel);
            }

            var item = ItemFactory.ToEntityItem(itemViewModel);
            var itemDetentora = ItemDetentoraFactory.ToEntityDetentoraItem(itemViewModel.CodigoDetentora, itemViewModel.Id);

            await _createItem.Run(item);
            await _createDetentoraItem.Run(itemDetentora);

            TempData["Success"] = "Item Cadastrado com Sucesso";

            return RedirectToAction(nameof(Create));
        }

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

        public async Task<IActionResult> AutoCompleteCodeItem(int yearAta, int codeAta)
        {
            var itens = await _searchItem.GetListItemByCodeAtaAndYearAtaIncludeDetentora(yearAta, codeAta);

            if (!itens.Any())
                return NotFound();

            var listItemViewModel = ItemFactory.ToListItemViewModel(itens);

            return PartialView("_ListItens", listItemViewModel);
        }

        public async Task FillViewBags(int yearAta)
        {
            ViewBag.ListYears = LoadDropYear();
            ViewBag.ListCodeAta = new SelectList(await _searchAta.GetListCodeByYear(yearAta));
            ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial");
        }

    }
}
