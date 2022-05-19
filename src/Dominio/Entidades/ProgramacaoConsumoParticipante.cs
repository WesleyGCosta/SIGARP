namespace Dominio.Entidades
{
    public class ProgramacaoConsumoParticipante
    {
        public int CodigoAta { get; private set; }
        public int AnoAta { get; private set; }
        public int CodigoItem { get; private set; }
        public int CodigoUnidadeAdministrativa { get; private set; }
        public int ConsumoEstimado { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal Aditivo { get; private set; }
        public decimal Transferido { get; private set; }
        public decimal SaldoAnterior { get; private set; }

        public ItemParticipante ItemParticipante { get; private set; }
    }
}
