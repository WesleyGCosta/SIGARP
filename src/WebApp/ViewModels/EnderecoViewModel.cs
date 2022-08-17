using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid DetentoraId { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(10, ErrorMessage = "{0} inválido")]
        public string Cep { get; set; }

        [Display(Name = "Rua")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 3)]
        public string Rua { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Numero { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 3)]
        public string Bairro { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public EUnidadeFederacao Uf { get; set; }

        [Display(Name = "Município")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 3)]
        public string Municipio { get; set; }
    }
}
