using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.ProgramacoesConsumos
{
    public class SearchProgramacoesConsumos
    {
        private readonly IProgramacaoConsumoParticipanteRepository _consumoParticipanteRepository;

        public SearchProgramacoesConsumos(IProgramacaoConsumoParticipanteRepository consumoParticipanteRepository)
        {
            _consumoParticipanteRepository = consumoParticipanteRepository;
        }

        public async Task<ProgramacaoConsumoParticipante> GetById(Guid id)
        {
            return await _consumoParticipanteRepository.GetByPrimaryKey(id);
        }
    }
}
