using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class DetentoraFactory
    {
        public static Detentora ToEntityDetentora(DetentoraViewModel detentoraViewModel)
        {
            var detentora = new Detentora(
                detentoraViewModel.Id,
                detentoraViewModel.Cnpj,
                detentoraViewModel.RazaoSocial,
                detentoraViewModel.NomeFantasia,
                detentoraViewModel.Email,
                detentoraViewModel.Telefone,
                detentoraViewModel.Pessoa
                );

            return detentora;
        }
    }
}
