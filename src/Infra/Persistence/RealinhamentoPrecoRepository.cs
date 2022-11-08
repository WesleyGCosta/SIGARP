using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistence
{
    public class RealinhamentoPrecoRepository : BaseRepository<RealinhamentoPreco>, IRealinhamentoPrecoRepository
    {
        public RealinhamentoPrecoRepository(DataContext db) : base(db)
        {
        }
    }
}
