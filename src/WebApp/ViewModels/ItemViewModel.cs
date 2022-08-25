using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.CustomValidation;

namespace WebApp.ViewModels
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            Id = Guid.NewGuid();
            Ativo = true;
        }

        public Guid Id { get; set; }

        [Display(Name = "Código do Item")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int CodigoItem { get; set; }

        [Display(Name = "Código da Ata")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int CodigoAta { get; set; }

        [Display(Name = "Ano da Ata")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int AnoAta { get; set; }

        [Display(Name = "Detentora")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public Guid CodigoDetentora { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public ETipo Tipo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Descricao { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 3)]
        public string Marca { get; set; }

        [Display(Name = "Unidade de Aquisição")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(20, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 2)]
        public string UnidadeAquisicao { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int Quantidade { get; set; }

        public int QuantidadeDisponivel
        {
            get => Quantidade;     
        }

        [Display(Name = "Preço de Mercado")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal PrecoMercado { get; set; }

        [Display(Name = "Preço Registrado")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MoreThan(nameof(PrecoMercado), ErrorMessage = "O {0} não pode ser maior que Preço de Mercado")]
        public decimal PrecoRegistrado { get; set; }
        public bool Ativo { get; set; }

        public DetentoraViewModel Detentora { get; set; }
        public ICollection<UnidadeAdministrativaViewModel> UnidadeAdministrativa { get; set; }
    }
}
