using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistencia
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(DataContext db) : base(db)
        {
        }

        public async Task<Item> GetLastItemByCodeAtaAndYearAta(int year, int code)
        {
            return await _db.Itens
                .AsNoTracking()
                .Where(i => i.CodigoAta.Equals(code) && i.AnoAta.Equals(year))
                .OrderByDescending(i => i.NumeroItem)
                .FirstOrDefaultAsync();
        }
    }
}
