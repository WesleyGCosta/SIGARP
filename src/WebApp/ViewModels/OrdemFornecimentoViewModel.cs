using System;

namespace WebApp.ViewModels
{
    public class OrdemFornecimentoViewModel
    {
        public OrdemFornecimentoViewModel()
        {
            Id = Guid.NewGuid();
            DataFornecimento = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid ProgramacaoConsumoId { get; set; }
        public DateTime DataFornecimento { get; set; }
        public string NumeroProcesso { get; set; }
        public int Consumo { get; set; }
        public int Saldo { get; set; }
    }
}
