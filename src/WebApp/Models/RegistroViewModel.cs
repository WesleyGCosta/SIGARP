using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Campo {0} é Obrigatório!")]
        public string Cpf { get; set; }

        
        [Required(ErrorMessage = "Campo {0} é Obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [Compare("Senha", ErrorMessage = "Senha e senha de confirmação não coincidem")]
        public string ConfirmarSenha { get; set; }
    }
}
