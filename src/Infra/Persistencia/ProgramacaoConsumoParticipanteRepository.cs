using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistencia
{
    public class ProgramacaoConsumoParticipanteRepository : BaseRepository<ProgramacaoConsumoParticipante>, IProgramacaoConsumoParticipanteRepository
    {
        public ProgramacaoConsumoParticipanteRepository(DataContext db) : base(db)
        {
        }
    }
}
