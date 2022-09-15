using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IParticipanteItemRepository : IBaseRepository<ParticipanteItem>
    {
        Task<ParticipanteItem> GetParticipanteItemByIds(Guid unidadeAdministrativaId, Guid itemId);
        Task<List<ParticipanteItem>> GetListByAta(int yearAta, int codeAta);
    }
}
