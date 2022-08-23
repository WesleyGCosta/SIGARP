using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IParticipanteItemRepository : IBaseRepository<ParticipanteItem>
    {
        Task<ParticipanteItem> GetParticipanteItemByIds(Guid unidadeAdministrativaId, Guid itemId);
    }
}
