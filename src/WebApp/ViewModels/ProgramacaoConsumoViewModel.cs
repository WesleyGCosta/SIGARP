using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels.CustomValidation;

namespace WebApp.ViewModels
{
    public class ProgramacaoConsumoViewModel
    {
        public ProgramacaoConsumoViewModel()
        {
            ParticipanteItemViewModel = new List<UnidadeAdministrativaViewModel>();
            OrdemFornecimentoViewModel = new OrdemFornecimentoViewModel();
        }

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

        public int NumeroItem { get; set; }

        [Display(Name = "Quantidade Disponível")]
        public int QuantidadeDisponivel { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Participante")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Guid CodigoUnidadeAdministrativa { get; set; }
        public string NomeUnidadeAdministrativa { get; set; }

        [Display(Name = "Consumo Estimado")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MoreThan(nameof(QuantidadeDisponivel), ErrorMessage = "O {0} não pode ser maior que Quantidade Disponível do Item")]
        public int ConsumoEstimado { get; set; }
        public int Saldo { get; set; }

        [Display(Name = "Saldo Disponível")]
        public int SaldoDisponivel { get; set; }
        public int Transferido { get; set; }
        public int SaldoAnterior { get; set; }
        public OrdemFornecimentoViewModel OrdemFornecimentoViewModel { get; set; }
        public ICollection<OrdemFornecimentoViewModel> Fornecimentos { get; set; }
        public ICollection<UnidadeAdministrativaViewModel> ParticipanteItemViewModel { get; set; }

        public int SumConsumoEstimado()
        {
            return ConsumoEstimado - SaldoAnterior;
        }

        internal void FillSaldo()
        {
            Saldo = ConsumoEstimado;
        }
    }
}
