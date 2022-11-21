using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Historia.Detentoras;
using Historia.DetentorasItem;
using Historia.Itens;
using Historia.RealinhamentosPrecos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class ItemController : BaseController
    {
        private readonly SearchAta _searchAta;
        private readonly SearchItem _searchItem;
        private readonly SearchDetentora _searchDetentora;
        private readonly SearchDetentoraItem _searchDetentoraItem;
        private readonly CreateItem _createItem;
        private readonly CreateDetentoraItem _createDetentoraItem;
        private readonly CreateRealinhamentoPreco _createRealinhamentoPreco;
        private readonly DeleteItem _deleteItem;
        private readonly UpdateItem _updateItem;
        private readonly UpdateDetentoraItem _updateDetentoraItem;

        public ItemController(
            IAtaRepository ataRepository,
            IItemRepository itemRepository,
            IDetentoraRepository detentoraRepository,
            IDetentoraItemRepository detentoraItemRepository,
            IRealinhamentoPrecoRepository realinhamentoPrecoRepository,
            INotifier notifier) : base(notifier)
        {
            _searchAta = new SearchAta(ataRepository);
            _searchItem = new SearchItem(itemRepository);
            _searchDetentora = new SearchDetentora(detentoraRepository);
            _searchDetentoraItem = new SearchDetentoraItem(detentoraItemRepository);
            _createItem = new CreateItem(itemRepository);
            _createRealinhamentoPreco = new CreateRealinhamentoPreco(realinhamentoPrecoRepository);
            _createDetentoraItem = new CreateDetentoraItem(detentoraItemRepository);
            _deleteItem = new DeleteItem(itemRepository);
            _updateItem = new UpdateItem(itemRepository);
            _updateDetentoraItem = new UpdateDetentoraItem(detentoraItemRepository);
        }

        #region "GETs"
        public async Task<IActionResult> Create()
        {
            ViewBag.ListYears = LoadDropYear();
            ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid itemId)
        {
            var item = await _searchItem.GetByIdInclude(itemId);
            var itemViewModel = ItemFactory.ToViewModel(item);

            if (itemViewModel.ItemDetentora != null)
                ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial", itemViewModel.ItemDetentora.Detentora.Id);
            else
                ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial");

            return PartialView("_FormEditItemModal", itemViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid itemId)
        {
            var item = await _searchItem.GetById(itemId);

            if (item.Equals(null))
            {
                TempData["Warning"] = "Erro, Item não encontrado";
                return NotFound();
            }

            var itemViewModel = ItemFactory.ToViewModel(item);

            return PartialView("_DetailsItemModal", itemViewModel);
        }


        //Excluir
        [HttpGet]
        public async Task<IActionResult> Delete(Guid itemId)
        {
            var item = await _searchItem.GetById(itemId);
            if (item.Equals(null))
            {
                TempData["Warning"] = "Erro ao Excluir Item";
                return NotFound();
            }

            await _deleteItem.Run(item);
            await _updateItem.Renumber(item.AnoAta, item.CodigoAta, item.NumeroItem);
            TempData["Success"] = "Item Excluído Com Sucesso";

            return await RedirectiListItem(item.AnoAta, item.CodigoAta);
        }

        //Suspender  Item
        [HttpGet]
        public IActionResult SuspendItem()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        [HttpGet]
        public IActionResult RealignPrice()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }

        //Realinhar Preco Item
        [HttpGet]
        public async Task<IActionResult> GetRealinhamento(Guid itemId)
        {
            var item = await _searchItem.GetById(itemId);
            var itemViewModel = ItemFactory.ToViewModel(item);

            return PartialView("_InfoItemRealinhamento", itemViewModel);
        }

        #endregion

        #region "POSTs"
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
            if (existe != null)
            {
                await FillViewBags(itemViewModel.AnoAta);
                TempData["Warning"] = $"Item {itemViewModel.CodigoItem} já existe na Ata {itemViewModel.CodigoAta}/{itemViewModel.AnoAta}";
                return View(itemViewModel);
            }

            var item = ItemFactory.ToEntityItem(itemViewModel);
            var itemDetentora = ItemDetentoraFactory.ToEntity(itemViewModel.CodigoDetentora, itemViewModel.Id);

            await _createItem.Run(item);
            await _createDetentoraItem.Run(itemDetentora);

            TempData["Success"] = "Item Cadastrado com Sucesso";

            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Warning"] = "Erro ao Editar o Item";
                return NotFound();
            }

            var item = ItemFactory.ToEntityItem(itemViewModel);
            var itemDetentoraEntity = ItemDetentoraFactory.ToEntity(itemViewModel.CodigoDetentora, itemViewModel.Id);

            await _updateItem.Run(item);

            var detentoraItem = await _searchDetentoraItem.GetByItemId(item.Id);

            if (detentoraItem == null)
                await _createDetentoraItem.Run(itemDetentoraEntity);
            else
                await _updateDetentoraItem.Run(itemDetentoraEntity);

            TempData["Success"] = "Item alterado com Sucesso";

            return await RedirectiListItem(item.AnoAta, item.CodigoAta);
        }

        [HttpPost]
        public async Task<IActionResult> ActiveInactiveItem(Guid itemId, bool status)
        {
            var item = await _searchItem.GetById(itemId);

            if (item == null)
            {
                TempData["Warning"] = "Erro na alteração do item";
                return Json("Error");
            }

            await _updateItem.ActiveInactiveItem(item, !status);

            TempData["Success"] = "Item alterado com Sucesso";


            return RedirectToAction(nameof(GetListItemSuspend), new { yearAta = item.AnoAta, codeAta = item.CodigoAta });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RealignPrice(RealinhamentoPrecoViewModel realinhamentoPrecoViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Warning"] = "Erro ao RealinharItem o Item";
                return Ok("Error");
            }


            var realinhamentoPreco = RealinhamentoPrecoFactory.ToEntity(realinhamentoPrecoViewModel);
            var item = await _searchItem.GetById(realinhamentoPreco.ItemId);
            await _updateItem.RealignPrice(realinhamentoPreco.PrecoMercado, realinhamentoPreco.PrecoRegistrado, item);
            await _createRealinhamentoPreco.Run(realinhamentoPreco);

            TempData["Success"] = "Realinhamento feito com sucesso";
            return RedirectToAction(nameof(GetListItemRealignPrice), new { yearAta = item.AnoAta, codeAta = item.CodigoAta });
        }

        #endregion

        #region "Functions"
        private async Task<IActionResult> RedirectiListItem(int yearAta, int codeAta)
        {
            var itens = await _searchItem.GetListItemByCodeAtaAndYearAta(yearAta, codeAta);
            var itensViewModel = ItemFactory.ToListViewModel(itens);

            return PartialView("_ListItensEdit", itensViewModel);
        }


        public async Task FillViewBags(int yearAta)
        {
            ViewBag.ListYears = LoadDropYear();
            ViewBag.ListCodeAta = new SelectList(await _searchAta.GetListCodeByYearPublish(yearAta, false));
            ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial");
        }
        #endregion

        #region "Consultas dinâmicas"

        [HttpGet]
        public async Task<IActionResult> GetListItemRealignPrice(int yearAta, int codeAta)
        {
            var itens = await _searchItem.GetListItemByCodeAtaAndYearAta(yearAta, codeAta);
            if (itens == null)
            {
                TempData["Warning"] = "Itens não encontrado";
                return Json("Error");
            }

            var itemViewModel = ItemFactory.ToListViewModel(itens);

            return PartialView("_ListItensRealignPrice", itemViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetListItemSuspend(int yearAta, int codeAta)
        {
            var itens = await _searchItem.GetListItemByCodeAtaAndYearAta(yearAta, codeAta);
            if (itens == null)
            {
                TempData["Warning"] = "Itens não encontrado";
                return Json("Error");
            }

            var itemViewModel = ItemFactory.ToListViewModel(itens);

            return PartialView("_ListItensSuspend", itemViewModel);
        }

        [HttpGet]
        public async Task<JsonResult> AutoCompleteListCodeAtaPublish(int yearAta, bool publish)
        {
            var listCodeAta = await _searchAta.GetListCodeByYearPublish(yearAta, publish);

            return Json(listCodeAta);
        }

        [HttpGet]
        public async Task<JsonResult> AutoCompleteListCodeItem(int yearAta, int codeAta)
        {
            var listItem = await _searchItem.GetListItemByCodeAtaAndYearAta(yearAta, codeAta);

            return Json(listItem);
        }

        [HttpGet]
        public async Task<IActionResult> AutoCompleteCodeItem(int yearAta, int codeAta)
        {
            var itens = await _searchItem.GetListItemByCodeAtaAndYearAtaIncludeDetentora(yearAta, codeAta);

            if (!itens.Any())
                return Ok("Error");

            var listItemViewModel = ItemFactory.ToListViewModel(itens);

            return PartialView("_ListItens", listItemViewModel);
        }
        #endregion
    }
}
