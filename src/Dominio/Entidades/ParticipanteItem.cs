using System;

namespace Dominio.Entidades
{
    public class ParticipanteItem
    {
        public Guid Id { get; private set; }
        public Guid ItemId { get; private set; }
        public Guid UnidadeAdministrativaId { get; private set; }

        public Item Item { get; private set; }
        public UnidadeAdministrativa UnidadeAdministrativa { get; private set; }
        public ProgramacaoConsumoParticipante ProgramacoesConsumoParticipantes { get; private set; }
    }
}
