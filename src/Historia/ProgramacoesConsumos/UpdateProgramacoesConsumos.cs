using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.ProgramacoesConsumos
{
    public class UpdateProgramacoesConsumos
    {
        private readonly IProgramacaoConsumoParticipanteRepository _programacaoConsumoParticipanteRepository;

        public UpdateProgramacoesConsumos(IProgramacaoConsumoParticipanteRepository programacaoConsumoParticipanteRepository)
        {
            _programacaoConsumoParticipanteRepository = programacaoConsumoParticipanteRepository;
        }

        public async Task Run(ProgramacaoConsumoParticipante programacaoConsumoParticipante)
        {
            var programacaoConsumoConsult = await _programacaoConsumoParticipanteRepository.GetByPrimaryKey(programacaoConsumoParticipante.Id);
            programacaoConsumoConsult.Update(programacaoConsumoParticipante.ConsumoEstimado);
            await _programacaoConsumoParticipanteRepository.Update(programacaoConsumoConsult);
        }
    }
}
