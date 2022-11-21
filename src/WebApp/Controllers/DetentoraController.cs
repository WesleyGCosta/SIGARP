using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Detentoras;
using Historia.DetentorasItem;
using Historia.Enderecos;
using Historia.Itens;
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
        private readonly UpdateDetentora _updateDetentora;
        private readonly UpdateEndereco _updateEndereco;
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
            _updateDetentora = new UpdateDetentora(detentoraRepository);
            _updateEndereco = new UpdateEndereco(enderecoRepository);
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
            var detentoraConsult = await _searchDetentora.GetByCnpj(detentoraViewModel.Cnpj);

            if (detentoraConsult != null)
            {
                TempData["Warning"] = "Detentora já cadastrado";
                return View(detentoraViewModel);
            }

            var detentora = DetentoraFactory.ToEntityDetentora(detentoraViewModel);
            var endereco = EnderecoFactory.ToEntityEndereco(detentoraViewModel.Endereco, detentoraViewModel.Id);

            await _createDetentora.Run(detentora);
            await _createEndereco.Run(endereco);

            TempData["Success"] = "Detentora Cadastrado com Sucesso";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Management() => View();


        public async Task<IActionResult> Edit(Guid id)
        {
            var detentora = await _searchDetentora.GetById(id);

            if (detentora == null)
            {
                TempData["Warning"] = "Detentora não encontrada";
                return NotFound();
            }

            var detentoraViewModel = DetentoraFactory.ToDetentoraViewModel(detentora);

            return PartialView("_DetentoraEditModal", detentoraViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DetentoraViewModel detentoraViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Warning"] = "Erro ao editar Detentora";
                return NotFound();
            }

            var detentora = DetentoraFactory.ToEntityDetentora(detentoraViewModel);
            var endereco = EnderecoFactory.ToEntityEndereco(detentoraViewModel.Endereco, detentoraViewModel.Id);
            await _updateDetentora.Run(detentora);
            await _updateEndereco.Run(endereco);

            TempData["Success"] = "Detentora Alterado com Sucesso";

            return RedirectToAction(nameof(GetDetentorasByStatus), new { status = detentoraViewModel.Ativo });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Guid id, bool status)
        {
            var detentora = await _searchDetentora.GetById(id);
            var success = await _updateDetentora.Run(id, status);

            if (!success)
            {
                TempData["Warning"] = "Erro na alteração da Unidade Administrativa";
                return NotFound();
            }

            TempData["Success"] = "Unidade Administrativa Alterado com Sucesso";

            return RedirectToAction(nameof(GetDetentorasByStatus), new { status = !status });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var detentora = await _searchDetentora.GetById(id);

            if (detentora == null)
            {
                TempData["Warning"] = "Detentora não encontrada";
                return NotFound();
            }

            var detentoraViewModel = DetentoraFactory.ToDetentoraViewModel(detentora);

            return PartialView("_DetentoraDetailsModal", detentoraViewModel);
        }

        public async Task<IActionResult> DeleteDetentoraItem(Guid detentoraId, int yearAta, int codeAta)
        {
            var participante = await _searchDetentoraItem.GetById(detentoraId);
            if (participante.Equals(null))
            {
                TempData["Warning"] = "Erro ao excluir participante do item";
                return NotFound();
            }

            await _deleteDetentoraItem.Run(participante);
            TempData["Success"] = "Detentora excluído do item com sucesso";

            return await UpdateListDetentora(yearAta, codeAta);
        }

        public async Task<IActionResult> UpdateListDetentora(int yearAta, int codeAta)
        {
            var detentorasItens = await _searchItem.GetListItemByCodeAtaAndYearAtaIncludeDetentora(yearAta, codeAta);
            var itensViewModel = ItemFactory.ToListViewModel(detentorasItens);
            return PartialView("_DetentorasEdit", itensViewModel);
        }


        public async Task<IActionResult> GetDetentorasByStatus(bool status)
        {
            if (status)
            {
                return PartialView("_DetentorasActive", await GetListDetentoraByStatus(status));
            }

            return PartialView("_DetentorasInactive", await GetListDetentoraByStatus(status));
        }


        private async Task<IList<DetentoraViewModel>> GetListDetentoraByStatus(bool status)
        {
            var detentoras = await _searchDetentora.GetByStatus(status);
            var listDetentorasViewModel = DetentoraFactory.ToListViewModel(detentoras);
            return listDetentorasViewModel;
        }
    }
}
