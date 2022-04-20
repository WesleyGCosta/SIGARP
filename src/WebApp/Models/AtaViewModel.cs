using Dominio.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AtaViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Número da Ata")]
        public int Numero { get; set; }

        [Display(Name = "Ano da Ata")]
        public int AnoAta { get; set; }

        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }

        [Display(Name = "Tipo de Pregão")]
        public EPregao TipoPregao { get; set; }

        [Display(Name = "Número do Pregão")]
        public string NumeroPregao { get; set; }

        [Display(Name = "Ano do Pregão")]
        public int AnoPregao { get; set; }

        [Display(Name = "Data de Homologação")]
        public DateTime DataHomologacao { get; set; }

        [Display(Name = "Data da Publicação no DOE")]
        public DateTime DataPublicacaoDOE { get; set; }

        public DateTime DataFinalVigencia { get; set; }

        [Display(Name = "Objeto Resumido")]
        public string ObjetoResumido { get; set; }

        public bool Publicada { get; set; }

        public DateTime DataPublicacaoSistema { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public string UsuarioCadastrado { get; set; }

        public DateTime DataCadastro { get; set; }

        public string UsuarioAlteracao { get; set; }

        public string DataAlteracao { get; set; }

        public float LimiteAdesao { get; set; }
    }
}
