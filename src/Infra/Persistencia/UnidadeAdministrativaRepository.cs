using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistencia
{
    public class UnidadeAdministrativaRepository : BaseRepository<UnidadeAdministrativa>, IUnidadeAdministrativaRepository
    {
        public UnidadeAdministrativaRepository(DataContext db) : base(db)
        {
        }
    }
}
