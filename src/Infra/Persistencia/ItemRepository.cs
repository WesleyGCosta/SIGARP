using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistencia
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(DataContext db) : base(db)
        {
        }
    }
}
