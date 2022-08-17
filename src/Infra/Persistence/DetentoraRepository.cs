using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistence
{
    public class DetentoraRepository : BaseRepository<Detentora>, IDetentoraRepository
    {
        public DetentoraRepository(DataContext db) : base(db)
        {
        }
    }
}
