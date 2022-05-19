using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class ItemParticipante
    {
        public int CodigoAta { get; private set; }
        public int AnoAta { get; private set; }
        public int CodigoItem { get; private set; }
        public int CodigoUnidadeAdministrativa { get; private set; }

        public Item Item { get; private set; }
        public IEnumerable<ProgramacaoConsumoParticipante> ProgramacaoConsumoParticipantes { get; private set; }
        public IEnumerable<UnidadeAdministrativa> UnidadesAdministrativas { get; private set; }
    }
}
