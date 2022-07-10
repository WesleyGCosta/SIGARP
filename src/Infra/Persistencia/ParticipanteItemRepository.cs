using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistencia
{
    public class ParticipanteItemRepository : BaseRepository<ParticipanteItem>, IParticipanteItemRepository
    {
        public ParticipanteItemRepository(DataContext db) : base(db)
        {
        }
    }
}
