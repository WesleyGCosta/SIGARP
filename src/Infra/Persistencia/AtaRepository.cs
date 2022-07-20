using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistencia
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
    }
}
