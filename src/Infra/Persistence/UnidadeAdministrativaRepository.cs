using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistence
{
    public class UnidadeAdministrativaRepository : BaseRepository<UnidadeAdministrativa>, IUnidadeAdministrativaRepository
    {
        public UnidadeAdministrativaRepository(DataContext db) : base(db)
        {
        }
    }
}
