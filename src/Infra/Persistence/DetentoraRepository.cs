using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class DetentoraRepository : BaseRepository<Detentora>, IDetentoraRepository
    {
        public DetentoraRepository(DataContext db) : base(db)
        {
        }

        public async Task<List<Detentora>> GetListDetentoraItemByAta(int yearAta, int codeAta)
        {
            return await _db.Detentoras
                .Where(d => d.DetentorasItens.Any(di => di.Item.AnoAta.Equals(yearAta) && di.Item.CodigoAta.Equals(codeAta)))
                .ToListAsync();
        }
    }
}
