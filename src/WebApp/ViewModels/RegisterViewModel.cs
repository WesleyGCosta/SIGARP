using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email/Login *")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato do {0} inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome *")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Sobrenome *")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Telefone *")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Cargo *")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Senha *")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha *")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Compare("Password", ErrorMessage = "Senha e senha de confirmação não coincidem")]
        public string ConfirmPassword { get; set; }
    }
}
