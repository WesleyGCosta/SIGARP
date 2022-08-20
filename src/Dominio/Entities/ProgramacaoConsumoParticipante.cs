using System;

namespace Domain.Entities
{
    public class ProgramacaoConsumoParticipante
    {
        public ProgramacaoConsumoParticipante(
            Guid id, 
            Guid participanteId, 
            int consumoEstimado, 
            decimal saldo, 
            decimal aditivo, 
            decimal transferido, 
            decimal saldoAnterior)
        {
            Id = id;
            ParticipanteId = participanteId;
            ConsumoEstimado = consumoEstimado;
            Saldo = saldo;
            Aditivo = aditivo;
            Transferido = transferido;
            SaldoAnterior = saldoAnterior;
        }

        public Guid Id { get; private set; }
        public Guid ParticipanteId { get; private set; }
        public int ConsumoEstimado { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal Aditivo { get; private set; }
        public decimal Transferido { get; private set; }
        public decimal SaldoAnterior { get; private set; }

        public ParticipanteItem ParticipanteItem { get; private set; }

    }
}
