using Domain.Entities;
using System;
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
                programacaoConsumoViewModel.Aditivo,
                programacaoConsumoViewModel.Transferido,
                programacaoConsumoViewModel.SaldoAnterior
                );
        }
    }
}
