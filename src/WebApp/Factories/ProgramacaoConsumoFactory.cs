using Domain.Entities;
using System.Linq;
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
            var programacaoViewModel = new ProgramacaoConsumoViewModel
            {
                NumeroItem = item.NumeroItem,
                Descricao = item.Descricao,
                QuantidadeDisponivel = item.QuantidadeDisponivel,
            };

            if (item.ParticipantesItens.Any(i => i.ProgramacoesConsumoParticipantes != null))
            {
                programacaoViewModel.Id = item.ParticipantesItens.Select(i => i.ProgramacoesConsumoParticipantes.Id).First();
                programacaoViewModel.ConsumoEstimado = item.ParticipantesItens.Select(i => i.ProgramacoesConsumoParticipantes.ConsumoEstimado).First();
                programacaoViewModel.NomeUnidadeAdministrativa = item.ParticipantesItens.Select(i => i.UnidadeAdministrativa.NomeUnidadeAdministrativa).First();
                programacaoViewModel.CodigoItem = item.Id;
                programacaoViewModel.AnoAta = item.AnoAta;
                programacaoViewModel.CodigoAta = item.CodigoAta;
            }

            if (item.ParticipantesItens.Any())
            {
                programacaoViewModel.ParticipanteItemViewModel = UnidadeAdministrativaFactory.ToListViewModel(item.ParticipantesItens);
            }

            return programacaoViewModel;
        }
        public static ProgramacaoConsumoViewModel ToViewModel(ProgramacaoConsumoParticipante programacaoConsumo)
        {
            return new ProgramacaoConsumoViewModel
            {
                Id = programacaoConsumo.Id,
                ParticipanteId = programacaoConsumo.ParticipanteId,
                ConsumoEstimado = programacaoConsumo.ConsumoEstimado,
                SaldoAnterior = programacaoConsumo.SaldoAnterior,
            };
        }

    }
}
