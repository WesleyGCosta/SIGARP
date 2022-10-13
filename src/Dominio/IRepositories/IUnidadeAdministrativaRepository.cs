using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUnidadeAdministrativaRepository : IBaseRepository<UnidadeAdministrativa>
    {
        Task<UnidadeAdministrativa> GetBySigla(string sigla);
        Task<List<UnidadeAdministrativa>> GetByStatus(bool status);
        Task<int> CountAll();
    }
}
