using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.CustomValidation;

namespace WebApp.ViewModels
{
    public class DetentoraViewModel
    {
        public DetentoraViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(18, ErrorMessage = "Por favor, insira um {0} válido.")]
        [CnpjValidation(ErrorMessage = "CNPJ inválido")]
        public string Cnpj { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 3)]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 3)]
        public string NomeFantasia { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do {0} inválido")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "Pessoa")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public EPessoa Pessoa { get; set; }
       
        public EnderecoViewModel Endereco { get; set; }
    }
}
