using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistence
{
    public class OrdemFornecimentoRepository : BaseRepository<OrdemFornecimento>, IOrdemFornecimentoRepository
    {
        public OrdemFornecimentoRepository(DataContext db) : base(db)
        {
        }
    }
}
