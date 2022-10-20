using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email/Login *")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato do {0} inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar de Mim")]
        public bool Lembrar { get; set; }
    }
}
