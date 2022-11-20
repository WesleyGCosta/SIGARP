using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class ParticipanteItemRepository : BaseRepository<ParticipanteItem>, IParticipanteItemRepository
    {
        public ParticipanteItemRepository(DataContext db) : base(db)
        {
        }

        public async Task<ParticipanteItem> GetByParticipanteId(Guid participanteId)
        {
            return await _db.ParticipantesItens
                .Include(pi => pi.Item)
                .Include(pi => pi.ProgramacoesConsumoParticipantes)
                .Include(pi => pi.UnidadeAdministrativa)
                .Where(pi => pi.Id.Equals(participanteId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<ParticipanteItem>> GetListByAta(int yearAta, int codeAta)
        {
            return await _db.ParticipantesItens
                .Include(pi => pi.Item)
                .Include(pi => pi.UnidadeAdministrativa)
                .Where(pi => pi.Item.AnoAta.Equals(yearAta) && pi.Item.CodigoAta.Equals(codeAta))
                .OrderBy(pi => pi.Item.NumeroItem)
                .ToListAsync();
        }

        public async Task<IEnumerable<ParticipanteItem>> GetListByUnidadeAdministrativaIdAndYearAta(Guid unidadeAdministrativaId, int yearAta)
        {
            return await _db.ParticipantesItens
                .AsNoTracking()
                .Include(pi => pi.Item)
                .ThenInclude(i => i.Ata)
                .Include(pi => pi.ProgramacoesConsumoParticipantes)
                .Include(pi => pi.UnidadeAdministrativa)
                .Where(pi => pi.UnidadeAdministrativaId.Equals(unidadeAdministrativaId)
                        && pi.Item.AnoAta.Equals(yearAta)
                        && pi.Item.Ata.Publicada.Equals(true)
                        && pi.Item.Ativo.Equals(true))
                .OrderBy(pi => pi.Item.CodigoAta)
                .ToListAsync();
        }

        public async Task<IEnumerable<ParticipanteItem>> GetListOrdemFornecimentoByUnidadeAdministrativaIdAndYearAta(Guid unidadeAdministrativaId, int yearAta)
        {
            return await _db.ParticipantesItens
                .AsNoTracking()
                .Include(pi => pi.Item)
                .ThenInclude(i => i.Ata)
                .Include(pi => pi.ProgramacoesConsumoParticipantes)
                .ThenInclude(pc => pc.OrdemFornecimentos)
                .Include(pi => pi.UnidadeAdministrativa)
                .Where(pi => pi.UnidadeAdministrativaId.Equals(unidadeAdministrativaId)
                        && pi.Item.AnoAta.Equals(yearAta)
                        && pi.Item.Ata.Publicada.Equals(true)
                        && pi.Item.Ativo.Equals(true)
                        && pi.ProgramacoesConsumoParticipantes.OrdemFornecimentos.Any())
                .OrderBy(pi => pi.Item.CodigoAta)
                .ToListAsync();
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
