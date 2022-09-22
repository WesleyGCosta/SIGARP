using Domain.Entities;
using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Detentoras;
using Historia.DetentorasItem;
using Historia.Enderecos;
using Historia.Itens;
using Historia.ParticipantesItens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class DetentoraController : BaseController
    {
        private readonly CreateDetentora _createDetentora;
        private readonly CreateEndereco _createEndereco;
        private readonly SearchDetentora _searchDetentora;

        private readonly SearchItem _searchItem;
        private readonly SearchDetentoraItem _searchDetentoraItem;
        private readonly DeleteDetentoraItem _deleteDetentoraItem;

        public DetentoraController(
            IDetentoraRepository detentoraRepository,
            IEnderecoRepository enderecoRepository,
            IDetentoraItemRepository detentoraItemRepository,
            IItemRepository itemRepository,
            INotifier notifier) : base(notifier)
        {
            _createDetentora = new CreateDetentora(detentoraRepository);
            _createEndereco = new CreateEndereco(enderecoRepository);
            _searchDetentora = new SearchDetentora(detentoraRepository);
            _searchItem = new SearchItem(itemRepository);
            _searchDetentoraItem = new SearchDetentoraItem(detentoraItemRepository);
            _deleteDetentoraItem = new DeleteDetentoraItem(detentoraItemRepository);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetentoraViewModel detentoraViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(detentoraViewModel);
            }

            var detentora = DetentoraFactory.ToEntityDetentora(detentoraViewModel);
            var endereco = EnderecoFactory.ToEntityEndereco(detentoraViewModel.Endereco, detentoraViewModel.Id);

            await _createDetentora.Run(detentora);
            await _createEndereco.Run(endereco);

            TempData["Success"] = "Detentora Cadastrado com Sucesso";

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Management()
        {
            var detentoras = await _searchDetentora.GetAll();
            var listDetentorasViewModel = DetentoraFactory.ToListViewModel(detentoras);
            return View(listDetentorasViewModel);
        }

        public async Task<IActionResult> DeleteDetentoraItem(Guid detentoraId, int yearAta, int codeAta)
        {
            var participante = await _searchDetentoraItem.GetById(detentoraId);
            if (participante.Equals(null))
            {
                TempData["Warning"] = "Erro ao Excluir Participante do Item";
                return NotFound();
            }

            await _deleteDetentoraItem.Run(participante);
            TempData["Success"] = "Detentora excluído do Item com Sucessso";

            return RedirectToAction("UpdateListDetentora", new { yearAta, codeAta });
        }

        public async Task<IActionResult> UpdateListDetentora(int yearAta, int codeAta)
        {
            var detentorasItens = await _searchItem.GetListItemByCodeAtaAndYearAtaIncludeDetentora(yearAta, codeAta);
            var itensViewModel = ItemFactory.ToListViewModel(detentorasItens);
            return PartialView("_DetentorasEdit", itensViewModel);
        }

        private IActionResult RedirectListDetentoraItem(IList<ItemViewModel> itemDetentorasViewModel)
        {
            return PartialView("_DetentorasEdit", itemDetentorasViewModel);
        }
    }
}
