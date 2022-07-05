using System;

namespace Domain.Entities
{
    public class ProgramacaoConsumoParticipante
    {
        public Guid ProgramacaoParticipanteId { get; private set; }
        public Guid ParticipanteId { get; private set; }
        public int ConsumoEstimado { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal Aditivo { get; private set; }
        public decimal Transferido { get; private set; }
        public decimal SaldoAnterior { get; private set; }

        public ParticipanteItem ParticipanteItem { get; private set; }

    }
}
