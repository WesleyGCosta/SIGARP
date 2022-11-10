using System;

namespace Domain.Entities
{
    public class OrdemFornecimento
    {
        public OrdemFornecimento(
            Guid id, 
            Guid programacaoConsumoParticipanteId, 
            DateTime dataFornecimento, 
            string numeroProcesso, 
            int consumo)
        {
            Id = id;
            ProgramacaoConsumoParticipanteId = programacaoConsumoParticipanteId;
            DataFornecimento = dataFornecimento;
            NumeroProcesso = numeroProcesso;
            Consumo = consumo;
        }

        public Guid Id { get; private set; }
        public Guid ProgramacaoConsumoParticipanteId { get; private set; }
        public DateTime DataFornecimento { get; private set; }
        public string NumeroProcesso { get; private set; }
        public int Consumo { get; private set; }

        public ProgramacaoConsumoParticipante ProgramacaoConsumoParticipante { get; private set; }
    }
}
