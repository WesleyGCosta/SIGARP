using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.ParticipantesItens
{
    public class CreateParticipanteItem
    {
        private readonly IParticipanteItemRepository _participanteItemRepository;

        public CreateParticipanteItem(IParticipanteItemRepository participanteItemRepository)
        {
            _participanteItemRepository = participanteItemRepository;
        }

        public async Task Run(ParticipanteItem participanteItem)
        {
            await _participanteItemRepository.Create(participanteItem);
        }
    }
}
