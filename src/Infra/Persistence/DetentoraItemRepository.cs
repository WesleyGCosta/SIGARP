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
    public class DetentoraItemRepository : BaseRepository<DetentoraItem>, IDetentoraItemRepository
    {
        public DetentoraItemRepository(DataContext db) : base(db)
        {
        }

        public async Task<DetentoraItem> GetByIdIncludes(Guid detentoraItemId)
        {
            return await _db.DetentorasItens
                .Include(di => di.Item)
                .Include(di => di.Detentora)
                .Where(di => di.Id.Equals(detentoraItemId))
                .FirstOrDefaultAsync();
        }

        public async Task<DetentoraItem> GetByIds(Guid detentoraId, Guid itemId)
        {
            return await _db.DetentorasItens
                .AsNoTracking()
                .Include(di => di.Item)
                .Where(di => di.DetentoraId.Equals(detentoraId) && di.ItemId.Equals(itemId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<DetentoraItem>> GetListDetentoraByAta(int yearAta, int codeAta)
        {
            return await _db.DetentorasItens
                .Include(di => di.Item)
                .Include(di => di.Detentora)
                .Where(di => di.Item.AnoAta.Equals(yearAta) && di.Item.CodigoAta.Equals(codeAta))
                .ToListAsync();
        }
    }
}
