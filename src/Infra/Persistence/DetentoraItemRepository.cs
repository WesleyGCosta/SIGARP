using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistence
{
    public class DetentoraItemRepository : BaseRepository<DetentoraItem>, IDetentoraItemRepository
    {
        public DetentoraItemRepository(DataContext db) : base(db)
        {
        }
    }
}
