using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class UnidadeAdministrativaFactory
    {
        public static UnidadeAdministrativa ToEntityUnidadeAdministrativa(UnidadeAdministrativaViewModel unidadeAdministrativaViewModel)
        {
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
    }
}
