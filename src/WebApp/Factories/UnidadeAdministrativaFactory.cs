using Domain.Entities;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class UnidadeAdministrativaFactory
    {
        public static UnidadeAdministrativa ToEntityUnidadeAdministrativa(UnidadeAdministrativaViewModel unidadeAdministrativaViewModel)
        {
            unidadeAdministrativaViewModel.UpperCase();
            var unidadeAdministrativa = new UnidadeAdministrativa(
                unidadeAdministrativaViewModel.Id,
                unidadeAdministrativaViewModel.NomeUnidadeAdministrativa,
                unidadeAdministrativaViewModel.Sigla,
                unidadeAdministrativaViewModel.OrgaoEx,
                unidadeAdministrativaViewModel.UnidadeDaFederacao,
                unidadeAdministrativaViewModel.EsferaAdministrativa,
                unidadeAdministrativaViewModel.Ativo
                );

            return unidadeAdministrativa;
        }

        public static UnidadeAdministrativaViewModel ToViewModel(UnidadeAdministrativa unidadeAdministrativa)
        {
            var unidadeAdministrativaViewModel = new UnidadeAdministrativaViewModel
            {
                Id = unidadeAdministrativa.Id,
                NomeUnidadeAdministrativa = unidadeAdministrativa.NomeUnidadeAdministrativa,
                Sigla = unidadeAdministrativa.Sigla,
                OrgaoEx = unidadeAdministrativa.OrgaoEx,
                UnidadeDaFederacao = unidadeAdministrativa.UnidadeDaFederacao,
                EsferaAdministrativa = unidadeAdministrativa.EsferaAdministrativa,
                Ativo = unidadeAdministrativa.Ativo
            };

            return unidadeAdministrativaViewModel;
        }

        public static List<UnidadeAdministrativaViewModel> ToListViewMode(IEnumerable<UnidadeAdministrativa> unidadeAdministrativas)
        {
            var list = new List<UnidadeAdministrativaViewModel>();
            foreach (var unidadeAdministrativa in unidadeAdministrativas)
                list.Add(ToViewModel(unidadeAdministrativa));

            return list;
        }

        internal static ICollection<UnidadeAdministrativaViewModel> ToListViewModel(IEnumerable<ParticipanteItem> participantesItens)
        {
            var list = new List<UnidadeAdministrativaViewModel>();
            foreach (var participante in participantesItens)
                list.Add(ToViewModel(participante.UnidadeAdministrativa));

            return list;
        }
    }
}
