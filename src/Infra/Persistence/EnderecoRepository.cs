using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;

namespace Infra.Persistence
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext db) : base(db)
        {
        }
    }
}
