using Domain.Entities;
using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Historia.Detentoras;
using Historia.DetentorasItem;
using Historia.Itens;
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
        private readonly DeleteItem _deleteItem;
        private readonly UpdateItem _updateItem;
        private readonly UpdateDetentoraItem _updateDetentoraItem;

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
            _searchDetentoraItem = new SearchDetentoraItem(detentoraItemRepository);
            _createItem = new CreateItem(itemRepository);
            _createDetentoraItem = new CreateDetentoraItem(detentoraItemRepository);
            _deleteItem = new DeleteItem(itemRepository); 
            _updateItem = new UpdateItem(itemRepository);
            _updateDetentoraItem = new UpdateDetentoraItem(detentoraItemRepository);
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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid itemId)
        {
            var item = await _searchItem.GetByIdInclude(itemId);
            var itemViewModel = ItemFactory.ToViewModel(item);

            if(itemViewModel.ItemDetentora != null)
                ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial", itemViewModel.ItemDetentora.Detentora.Id);
            else
                ViewBag.ListDetentora = new SelectList(await _searchDetentora.GetAll(), "Id", "RazaoSocial");

            return PartialView("_FormEditItemModal", itemViewModel);
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
            await _updateItem.Renumber(item.NumeroItem);
            TempData["Success"] = "Item Excluído Com Sucesso";

            return await RedirectiListItem(item.AnoAta, item.CodigoAta);
        }

        private async Task<IActionResult> RedirectiListItem(int yearAta, int codeAta)
        {
            var itens = await _searchItem.GetListItemByCodeAtaAndYearAta(yearAta, codeAta);
            var itensViewModel = ItemFactory.ToListViewModel(itens);

            return PartialView("_ListItensEdit", itensViewModel);
        }

        //Consultas dinâmica
        [HttpGet]
        public async Task<JsonResult> AutoCompleteListCodeAta(int yearAta)
        {
            var listCodeAta = await _searchAta.GetListCodeByYear(yearAta);

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
                return NotFound();

            var listItemViewModel = ItemFactory.ToListViewModel(itens);

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
