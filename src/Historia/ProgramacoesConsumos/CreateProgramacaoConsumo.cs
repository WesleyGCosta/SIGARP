using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.ProgramacoesConsumos
{
    public class CreateProgramacaoConsumo
    {
        private readonly IProgramacaoConsumoParticipanteRepository _programacaoConsumoRepository;

        public CreateProgramacaoConsumo(IProgramacaoConsumoParticipanteRepository programacaoConsumoRepository)
        {
            _programacaoConsumoRepository = programacaoConsumoRepository;
        }

        public async Task Run(ProgramacaoConsumoParticipante programacaoConsumoParticipante)
        {
            await _programacaoConsumoRepository.Create(programacaoConsumoParticipante);
        }
    }
}
