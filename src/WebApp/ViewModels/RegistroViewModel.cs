using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Cpf { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Compare("Senha", ErrorMessage = "Senha e senha de confirmação não coincidem")]
        public string ConfirmarSenha { get; set; }
    }
}
