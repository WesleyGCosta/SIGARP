using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Ata
    {
        public int CodigoAta { get; private set; }
        public int AnoAta { get; private set; }
        public string NumeroProcesso { get; private set; }
        public string NumeroPregao { get; private set; }
        public int AnoPregao { get; private set; }
        public DateTime DataHomologacao { get; private set; }
        public DateTime DataPublicacaoDOE { get; private set; }
        public DateTime DataFinalVigencia { get; private set; }
        public string ObjetoResumido { get; private set; }
        public bool Publicada { get; private set; }
        public DateTime DataPublicacaoSistema { get; private set; }
        public string Observacao { get; private set; }
        public float LimiteAdesao { get; private set; }

        public IEnumerable<Item> Itens { get; private set; }
    }
}
