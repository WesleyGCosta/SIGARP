using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.ParticipantesItens
{
    public class DeleteParticipanteItem
    {
        private IParticipanteItemRepository _participanteItemRepository;

        public DeleteParticipanteItem(IParticipanteItemRepository participanteItemRepository)
        {
            _participanteItemRepository = participanteItemRepository;
        }

        public async Task Run(ParticipanteItem participanteItem)
        {
            await _participanteItemRepository.Delete(participanteItem);
        }
    }
}
