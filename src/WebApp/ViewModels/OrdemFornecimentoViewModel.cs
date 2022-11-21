using System;
using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.CustomValidation;

namespace WebApp.ViewModels
{
    public class OrdemFornecimentoViewModel
    {
        public OrdemFornecimentoViewModel()
        {
            Id = Guid.NewGuid();
            DataFornecimento = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid ProgramacaoConsumoId { get; set; }
        public DateTime DataFornecimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Número do Processo")]
        [MinLength(18, ErrorMessage = "Número de {0} inválido!")]
        public string NumeroProcesso { get; set; }

        [MoreThan(nameof(Saldo), ErrorMessage = "O {0} não pode ser maior que Saldo Disponível")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Range(1, double.PositiveInfinity, ErrorMessage = "O {0} tem que ser maior que 0")]
        public int Consumo { get; set; }
        public int Saldo { get; set; }
    }
}
