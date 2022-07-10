﻿using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class AtaViewModel
    {
        public AtaViewModel()
        {
            DataCadastro = DateTime.Now;
        }

        [Display(Name = "Número da Ata")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Range(1, 1000, ErrorMessage = "Números de 1 à 1000")]
        public int NumeroAta { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Ano da Ata")]
        public int AnoAta { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Tipo de Pregão")]
        public EPregao TipoPregao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Número do Pregão")]
        public string NumeroPregao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Ano do Pregão")]
        public int AnoPregao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data de Homologação")]
        public DateTime DataHomologacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data da Publicação no DOE")]
        public DateTime DataPublicacaoDOE { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataFinalVigencia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Objeto Resumido")]
        public string ObjetoResumido { get; set; }

        public bool Publicada { get; set; }

        public DateTime DataPublicacaoSistema { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Limite de Adesão")]
        public int LimiteAdesao { get; set; }
    }
}
