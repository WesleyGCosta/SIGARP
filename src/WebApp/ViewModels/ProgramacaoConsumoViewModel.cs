using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ProgramacaoConsumoViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ParticipanteId { get; set; } = Guid.NewGuid();

        [Display(Name = "Código Ata")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoAta { get; set; }

        [Display(Name = "Ano Ata")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int AnoAta { get; set; }

        [Display(Name = "Código Item")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Guid CodigoItem { get; set; }

        [Display(Name = "Participante")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Guid CodigoUnidadeAdministrativa { get; set; }

        [Display(Name = "Consumo Estimado")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int ConsumoEstimado { get; set; }
        public decimal Saldo { get; set; }
        public decimal Aditivo { get; set; }
        public decimal Transferido { get; set; }
        public decimal SaldoAnterior { get; set; }
    }
}
