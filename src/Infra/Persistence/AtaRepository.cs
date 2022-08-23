using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class AtaRepository : BaseRepository<Ata>, IAtaRepository
    {
        public AtaRepository(DataContext db) : base(db)
        {
        }

        public async Task<Ata> GetByYear(int year)
        {
            return await _db.Atas
                .AsNoTracking()
                .Where(a => a.AnoAta.Equals(year))
                .OrderByDescending(a => a.CodigoAta)
                .FirstOrDefaultAsync();
        }

        public async Task<Ata> GetByYearAndCode(int year, int code)
        {
            return await _db.Atas
                .AsNoTracking()
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                .ThenInclude(i => i.DetentoraItem)
                .ThenInclude(d => d.Detentora)
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                .ThenInclude(i => i.ParticipantesItens)
                .ThenInclude(pt => pt.UnidadeAdministrativa)
                .Where(a => a.AnoAta.Equals(year) && a.CodigoAta.Equals(code))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Ata>> GetListAtaByYear(int year)
        {
            return await _db.Atas
                .Where(a => a.AnoAta.Equals(year))
                .OrderBy(a => a.CodigoAta)
                .ToListAsync();
        }

        public async Task<List<int>> GetListCodeByYear(int year)
        {
            return await _db.Atas
                .AsNoTracking()
                .Where(a => a.AnoAta.Equals(year))
                .Select(a => a.CodigoAta)
                .ToListAsync();
        }
    }
}
