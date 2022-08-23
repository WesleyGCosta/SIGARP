using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Threading.Tasks;

namespace Historia.ParticipantesItens
{
    public class SearchParticipanteItem
    {
        private readonly IParticipanteItemRepository _participanteItemRepository;

        public SearchParticipanteItem(IParticipanteItemRepository participanteItemRepository)
        {
            _participanteItemRepository = participanteItemRepository;
        }

        public async Task<ParticipanteItem> GetByIds(Guid unidadeAdministrativaId, Guid itemId)
        {
            return await _participanteItemRepository.GetParticipanteItemByIds(unidadeAdministrativaId, itemId);
        }
    }
}
