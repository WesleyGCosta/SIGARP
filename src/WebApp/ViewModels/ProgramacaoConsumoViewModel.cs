using System;

namespace WebApp.ViewModels
{
    public class ProgramacaoConsumoViewModel
    {
        public int CodigoAta { get; set; }
        public int AnoAta { get; set; }
        public Guid CodigoItem { get; set; }
        public Guid CodigoUnidadeAdministrativa { get; set; }
        public decimal ConsumoEstimado { get; set; }
        public decimal Saldo { get; set; }
        public decimal Aditivo { get; set; }
        public decimal Transferido { get; set; }
        public decimal SaldoAnterior { get; set; }
    }
}
