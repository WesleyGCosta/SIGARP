using System;

namespace Domain.Entities
{
    public class ProgramacaoConsumoParticipante
    {
        public ProgramacaoConsumoParticipante(
            Guid id, 
            Guid participanteId, 
            int consumoEstimado, 
            int saldo, 
            int transferido, 
            int saldoAnterior)
        {
            Id = id;
            ParticipanteId = participanteId;
            ConsumoEstimado = consumoEstimado;
            Saldo = saldo;
            Transferido = transferido;
            SaldoAnterior = saldoAnterior;
        }

        public Guid Id { get; private set; }
        public Guid ParticipanteId { get; private set; }
        public int ConsumoEstimado { get; private set; }
        public int Saldo { get; private set; }
        public int Transferido { get; private set; }
        public int SaldoAnterior { get; private set; }

        public ParticipanteItem ParticipanteItem { get; private set; }

    }
}
