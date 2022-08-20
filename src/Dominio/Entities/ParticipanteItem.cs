using System;

namespace Domain.Entities
{
    public class ParticipanteItem
    {
        public ParticipanteItem(Guid id, Guid itemId, Guid unidadeAdministrativaId)
        {
            Id = id;
            ItemId = itemId;
            UnidadeAdministrativaId = unidadeAdministrativaId;
        }

        public Guid Id { get; private set; }
        public Guid ItemId { get; private set; }
        public Guid UnidadeAdministrativaId { get; private set; }

        public Item Item { get; private set; }
        public UnidadeAdministrativa UnidadeAdministrativa { get; private set; }
        public ProgramacaoConsumoParticipante ProgramacoesConsumoParticipantes { get; private set; }
    }
}
