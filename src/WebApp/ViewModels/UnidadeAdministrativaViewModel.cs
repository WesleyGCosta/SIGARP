using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class UnidadeAdministrativaViewModel
    {
        public UnidadeAdministrativaViewModel()
        {
            Id = Guid.NewGuid();
            Ativo = true;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Unidade ou Órgão")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 5)]
        public string NomeUnidadeAdministrativa { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Sigla")]
        [StringLength(10, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 2)]

        public string Sigla { get; set; }

        [Display(Name = "Admin. Direta / Indireta do Governo RO?")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool OrgaoEx { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Unidade da Federação")]
        [StringLength(50, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 5)]
        public string UnidadeDaFederacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Esfera Administrativa")]
        public EhEsferaAdministrativa EsferaAdministrativa { get; set; }
        public bool Ativo { get; set; }

    }
}
