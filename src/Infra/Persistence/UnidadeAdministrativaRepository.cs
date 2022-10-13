using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class UnidadeAdministrativaRepository : BaseRepository<UnidadeAdministrativa>, IUnidadeAdministrativaRepository
    {
        public UnidadeAdministrativaRepository(DataContext db) : base(db)
        {
        }

        public async Task<int> CountAll()
        {
            return await _db.UnidadesAdministrativas
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<UnidadeAdministrativa> GetBySigla(string sigla)
        {
            return await _db.UnidadesAdministrativas
                .AsNoTracking()
                .Where(ua => ua.Sigla.Equals(sigla))
                .FirstOrDefaultAsync();
        }

        public async Task<List<UnidadeAdministrativa>> GetByStatus(bool status)
        {
            return await _db.UnidadesAdministrativas
                .AsNoTracking()
                .Where(u => u.Ativo.Equals(status))
                .ToListAsync();
        }
    }
}
