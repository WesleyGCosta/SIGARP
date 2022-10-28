using Domain.Entities;
using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Itens;
using Historia.ParticipantesItens;
using Historia.ProgramacoesConsumos;
using Historia.UnidadesAdministrativas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProgramacaoConsumoController : BaseController
    {
        private readonly SearchUnidadeAdministrativa _searchUnidadeAdministrativa;
        private readonly SearchParticipanteItem _searchParticipanteItem;
        private readonly SearchItem _searchItem;
        private readonly UpdateItem _updateItem;
        private readonly UpdateProgramacoesConsumos _updateProgramacoesConsumos;
        private readonly CreateProgramacaoConsumo _createProgramacaoConsumo;
        private readonly CreateParticipanteItem _createParticipanteItem;
        public ProgramacaoConsumoController(
            IUnidadeAdministrativaRepository unidadeAdministrativaRepository,
            IProgramacaoConsumoParticipanteRepository programacaoConsumoParticipanteRepository,
            IParticipanteItemRepository participanteItemRepository,
            IItemRepository itemRepository,
            INotifier notifier) : base(notifier)
        {
            _searchUnidadeAdministrativa = new SearchUnidadeAdministrativa(unidadeAdministrativaRepository);
            _searchParticipanteItem = new SearchParticipanteItem(participanteItemRepository);
            _searchItem = new SearchItem(itemRepository);
            _updateItem = new UpdateItem(itemRepository);
            _updateProgramacoesConsumos = new UpdateProgramacoesConsumos(programacaoConsumoParticipanteRepository);
            _createProgramacaoConsumo = new CreateProgramacaoConsumo(programacaoConsumoParticipanteRepository);
            _createParticipanteItem = new CreateParticipanteItem(participanteItemRepository);
        }

        public async Task<IActionResult> Create()
        {
            await FillViewBags();
            return View();
        }

        private async Task FillViewBags()
        {
            ViewBag.ListYears = LoadDropYear();
            ViewBag.ListUnidadeAdministrativa = new SelectList(await _searchUnidadeAdministrativa.GetAllUnidadeActive(), "Id", "Exibicao");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgramacaoConsumoViewModel programacaoConsumoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(programacaoConsumoViewModel);
            }
            var existsParticipante = await _searchParticipanteItem.GetByIds(programacaoConsumoViewModel.CodigoUnidadeAdministrativa, programacaoConsumoViewModel.CodigoItem);
            if (existsParticipante != null)
            {
                TempData["Warning"] = "Já existe uma programação de consumo para esse participante";
                return Ok("Error");
            }

            var participante = ParticipanteItemFactory.ToEntity(programacaoConsumoViewModel.ParticipanteId, programacaoConsumoViewModel.CodigoItem, programacaoConsumoViewModel.CodigoUnidadeAdministrativa);
            var programacaoConsumo = ProgramacaoConsumoFactory.ToEntity(programacaoConsumoViewModel);

            await _createParticipanteItem.Run(participante);
            await _createProgramacaoConsumo.Run(programacaoConsumo);
            await _updateItem.SubtractQuantityItem(programacaoConsumoViewModel.CodigoItem, programacaoConsumo.ConsumoEstimado);

            TempData["Success"] = "Programação Incluída com Sucesso";

            return Ok();
        }

        public async Task<IActionResult> Edit(Guid participanteId)
        {
            var itemContainsParticipante = await _searchItem.GetByParticipanteId(participanteId);

            var programacaoConsumoViewModel = ProgramacaoConsumoFactory.ToViewModel(itemContainsParticipante);

            return PartialView("_ProgramacaoConsumoEditModal", programacaoConsumoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProgramacaoConsumoViewModel programacaoConsumoViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Warning"] = "Erro na Alteração da Programação de Consumo";
                return NotFound();
            }
            var programacaoConsumo = ProgramacaoConsumoFactory.ToEntity(programacaoConsumoViewModel);
            await _updateProgramacoesConsumos.Run(programacaoConsumo);
            await _updateItem.SubtractQuantityItem(programacaoConsumoViewModel.CodigoItem, programacaoConsumoViewModel.SumConsumoEstimado());
            TempData["Success"] = "Programação de consumo alterado com sucesso";
            return Ok();
        }

        public async Task<IActionResult> GetItemIncludeUnidadeAdministrativa(int yearAta, int codeAta, int codeItem)
        {
            var item = await _searchItem.GetItemByCodeAtaAndYearAtaIncludeUnidadeAdministrativa(yearAta, codeAta, codeItem);

            if (item == null)
                return NotFound();

            var programacaoConsumoViewModel = ProgramacaoConsumoFactory.ToViewModel(item);
            await FillViewBags();
            return PartialView("_ItemDatailsProgramacaoConsumo", programacaoConsumoViewModel);
        }

        public IActionResult Management()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }
    }
}
