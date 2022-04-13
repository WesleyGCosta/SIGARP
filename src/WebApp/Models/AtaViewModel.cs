using Dominio.Enums;
using System;

namespace WebApp.Models
{
    public class AtaViewModel
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public int AnoAta { get; set; }
        public string NumeroProcesso { get; set; }
        public EPregao TipoPregao { get; set; }
        public string NumeroPregao { get; set; }
        public int AnoPregao { get; set; }
        public DateTime DataHomologacao { get; set; }
        public DateTime DataPublicacaoDOE { get; set; }
        public DateTime DataFinalVigencia { get; set; }
        public string ObjetoResumido { get; set; }
        public bool Publicada { get; set; }
        public DateTime DataPublicacaoSistema { get; set; }
        public string Observacao { get; set; }
        public string UsuarioCadastrado { get; set; }
        public DateTime DataCadastro { get; set; }
        public string UsuarioAlteracao { get; set; }
        public string DataAlteracao { get; set; }
        public float LimiteAdesao { get; set; }
    }
}
