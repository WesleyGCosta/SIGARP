using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Atas;
using Historia.Itens;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ItemController : BaseController
    {
        private readonly SearchAta _searchAta;
        private readonly SearchItem _searchItem;
        private readonly CreateItem _createItem;
        public ItemController(
            IAtaRepository ataRepository,
            IItemRepository itemRepository,
            INotifier notifier) : base(notifier)
        {
            _searchAta = new SearchAta(ataRepository);
            _searchItem = new SearchItem(itemRepository);
            _createItem = new CreateItem(itemRepository);
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
                return View(itemViewModel);
            }

            var item = ItemFactory.ToEntityItem(itemViewModel);

            await _createItem.Run(item);

            TempData["Success"] = "Item Cadastrado com Sucesso";

            return RedirectToAction("Index", "Home");
        }

        public async Task<JsonResult> AutoCompleteListCodeAta(int yearAta)
        {

            var listCodeAta = await _searchAta.GetListCodeByYear(yearAta);

            return Json(listCodeAta);
        }

        public async Task<JsonResult> AutoCompleteCodeItem(int yearAta, int codeAta)
        {
            var lastItem = await _searchItem.GetLastItemByCodeAtaAndYearAta(yearAta, codeAta);

            if (lastItem == null)
                return Json(1);

            return Json(lastItem.NumeroItem + 1);
        }
    }
}
