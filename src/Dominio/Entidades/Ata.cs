using Dominio.Enums;
using System;

namespace Dominio.Entidades
{
    public class Ata
    {
        public Guid Id { get; private set; }
        public int Numero { get; private set; }
        public int AnoAta { get; private set; }
        public string NumeroProcesso { get; private set; }
        public EPregao TipoPregao { get; private set; }
        public string NumeroPregao { get; private set; }
        public int AnoPregao { get; private set; }
        public DateTime DataHomologacao { get; private set; }
        public DateTime DataPublicacaoDOE { get; private set; }
        public DateTime DataFinalVigencia { get; private set; }
        public string ObjetoResumido { get; private set; }
        public bool Publicada { get; private set; }
        public DateTime DataPublicacaoSistema { get; private set; }
        public string Observacao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string DataAlteracao { get; private set; }
        public int LimiteAdesao { get; private set; }
    }
}
