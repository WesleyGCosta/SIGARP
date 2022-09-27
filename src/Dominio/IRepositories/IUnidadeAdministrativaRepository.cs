using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUnidadeAdministrativaRepository : IBaseRepository<UnidadeAdministrativa>
    {
        Task<UnidadeAdministrativa> GetBySigla(string sigla);
    }
}
