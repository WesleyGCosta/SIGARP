using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistencia
{
    public class AtaRepository : BaseRepository<Ata>, IAtaRepository
    {
        public AtaRepository(DataContext db) : base(db)
        {
        }
    }
}
