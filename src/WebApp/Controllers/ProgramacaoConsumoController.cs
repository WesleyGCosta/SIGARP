using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.Itens;
using Historia.ParticipantesItens;
using Historia.ProgramacoesConsumos;
using Historia.UnidadesAdministrativas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.ListUnidadeAdministrativa = new SelectList(await _searchUnidadeAdministrativa.GetAll(), "Id", "Exibicao");
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
                TempData["Warning"] = $"Programação de Consumo já existe";
                return NotFound();
            }

            var participante = ParticipanteItemFactory.ToEntity(programacaoConsumoViewModel.ParticipanteId, programacaoConsumoViewModel.CodigoItem, programacaoConsumoViewModel.CodigoUnidadeAdministrativa);
            var programacaoConsumo = ProgramacaoConsumoFactory.ToEntity(programacaoConsumoViewModel);

            await _createParticipanteItem.Run(participante);
            await _createProgramacaoConsumo.Run(programacaoConsumo);
            await _updateItem.SubtractQuantityItem(programacaoConsumoViewModel.CodigoItem, programacaoConsumo.ConsumoEstimado);

            TempData["Success"] = "Programação Incluída com Sucesso";
            await FillViewBags();

            return Ok();
        }

        public async Task<IActionResult> GetItemIncludeUnidadeAdministrativa(int yearAta, int codeAta, int codeItem)
        {
            var item = await _searchItem.GetItemByCodeAtaAndYearAtaIncludeUnidadeAdministrativa(yearAta, codeAta, codeItem);

            if (item == null)
                return NotFound();

            var listItemViewModel = ProgramacaoConsumoFactory.ToViewModel(item);

            return PartialView("_ItemDatailsProgramacaoConsumo", listItemViewModel);
        }

        public IActionResult Management()
        {
            ViewBag.ListYears = LoadDropYear();
            return View();
        }
    }
}
