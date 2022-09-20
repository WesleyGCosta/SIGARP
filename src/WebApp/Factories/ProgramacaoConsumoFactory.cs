using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class ProgramacaoConsumoFactory
    {
        public static ProgramacaoConsumoParticipante ToEntity(ProgramacaoConsumoViewModel programacaoConsumoViewModel)
        {
            return new ProgramacaoConsumoParticipante(
                programacaoConsumoViewModel.Id,
                programacaoConsumoViewModel.ParticipanteId,
                programacaoConsumoViewModel.ConsumoEstimado,
                programacaoConsumoViewModel.Saldo,
                programacaoConsumoViewModel.Transferido,
                programacaoConsumoViewModel.SaldoAnterior
                );
        }

        public static ProgramacaoConsumoViewModel ToViewModel(Item item)
        {
            return new ProgramacaoConsumoViewModel
            {
                NumeroItem = item.NumeroItem,
                Descricao = item.Descricao,
                QuantidadeDisponivel = item.QuantidadeDisponivel,
            };
        }
    }
}
