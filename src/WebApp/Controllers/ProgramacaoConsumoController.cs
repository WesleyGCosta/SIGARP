using Domain.IRepositories;
using Domain.Notifications.Interface;
using Historia.ParticipantesItens;
using Historia.ProgramacoesConsumos;
using Historia.UnidadesAdministrativas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProgramacaoConsumoController : BaseController
    {
        private readonly SearchUnidadeAdministrativa _searchUnidadeAdministrativa;
        private readonly SearchParticipanteItem _searchParticipanteItem;
        private readonly CreateProgramacaoConsumo _createProgramacaoConsumo;
        private readonly CreateParticipanteItem _createParticipanteItem;
        public ProgramacaoConsumoController(
            IUnidadeAdministrativaRepository unidadeAdministrativaRepository,
            IProgramacaoConsumoParticipanteRepository programacaoConsumoParticipanteRepository,
            IParticipanteItemRepository participanteItemRepository,
            INotifier notifier) : base(notifier)
        {
            _searchUnidadeAdministrativa = new SearchUnidadeAdministrativa(unidadeAdministrativaRepository);
            _searchParticipanteItem = new SearchParticipanteItem(participanteItemRepository);
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
        //[ValidateAntiForgeryToken]
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

            TempData["Success"] = "Programação Incluída com Sucesso";
            await FillViewBags();

            return Ok();
        }
    }
}
