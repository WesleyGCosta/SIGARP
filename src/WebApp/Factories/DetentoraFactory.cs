using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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
                detentoraViewModel.Pessoa,
                detentoraViewModel.Ativo
                );

            return detentora;
        }

        public static DetentoraViewModel ToDetentoraViewModel(Detentora detentora)
        {
            var detentoraViewModel = new DetentoraViewModel
            {
                Id = detentora.Id,
                Cnpj = detentora.Cnpj,
                RazaoSocial = detentora.RazaoSocial,
                NomeFantasia = detentora.NomeFantasia,
                Email = detentora.Email,
                Telefone = detentora.Telefone,
                Pessoa = detentora.Pessoa,
                Ativo = detentora.Ativo

            };
            if (detentora.Enderecos != null)
            {
                detentoraViewModel.Endereco = EnderecoFactory.ToViewModel(detentora.Enderecos.FirstOrDefault());
                detentoraViewModel.Enderecos = EnderecoFactory.ToListViewModel(detentora.Enderecos);
            }


            return detentoraViewModel;
        }

        public static IList<DetentoraViewModel> ToListViewModel(List<Detentora> detentoras)
        {
            var list = new List<DetentoraViewModel>();
            foreach (var detentora in detentoras)
                list.Add(ToDetentoraViewModel(detentora));

            return list;
        }
    }
}
