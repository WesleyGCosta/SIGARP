using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class DetentoraItemRepository : BaseRepository<DetentoraItem>, IDetentoraItemRepository
    {
        public DetentoraItemRepository(DataContext db) : base(db)
        {
        }

        public async Task<DetentoraItem> GetByIds(Guid detentoraId, Guid itemId)
        {
            return await _db.DetentorasItens
                .AsNoTracking()
                .Include(di => di.Item)
                .Where(di => di.DetentoraId.Equals(detentoraId) && di.ItemId.Equals(itemId))
                .FirstOrDefaultAsync();
        }
    }
}
