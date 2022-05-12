using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo {0} é Obrigatório!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo {0} é Obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembrar de Mim")]
        public bool Lembrar { get; set; }
    }
}
