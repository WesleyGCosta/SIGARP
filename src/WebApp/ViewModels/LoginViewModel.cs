using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembrar de Mim")]
        public bool Lembrar { get; set; }
    }
}
