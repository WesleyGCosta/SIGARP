using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class ParticipanteItemRepository : BaseRepository<ParticipanteItem>, IParticipanteItemRepository
    {
        public ParticipanteItemRepository(DataContext db) : base(db)
        {
        }

        public async Task<ParticipanteItem> GetParticipanteItemByIds(Guid unidadeAdministrativaId, Guid itemId)
        {
            return await _db.ParticipantesItens
                .AsNoTracking()
                .Include(pt => pt.ProgramacoesConsumoParticipantes)
                .Where(pt => pt.UnidadeAdministrativaId.Equals(unidadeAdministrativaId) && pt.ItemId.Equals(itemId))
                .FirstOrDefaultAsync();
        }
    }
}
