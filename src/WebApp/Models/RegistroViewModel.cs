using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class RegistroViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [Compare("Senha", ErrorMessage = "Senha e senha de confirmação não coincidem")]
        public string ConfirmarSenha { get; set; }
    }
}
