using Domain.Entities;
using System;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class EnderecoFactory
    {
        public static Endereco ToEntityEndereco(EnderecoViewModel enderecoViewModel, Guid detentoraId)
        {
            var endereco = new Endereco(
                enderecoViewModel.Id,
                detentoraId: detentoraId,
                enderecoViewModel.Cep,
                enderecoViewModel.Rua,
                enderecoViewModel.Numero,
                enderecoViewModel.Bairro,
                enderecoViewModel.Uf,
                enderecoViewModel.Municipio
                );

            return endereco;
        }

        public static EnderecoViewModel ToViewModel(Endereco endereco)
        {
            return new EnderecoViewModel
            {
                Id = endereco.Id,
                DetentoraId = endereco.DetentoraId,
                Cep = endereco.Cep,
                Rua = endereco.Rua,
                Numero = endereco.Numero,
                Bairro = endereco.Bairro,
                Uf = endereco.Uf,
                Municipio = endereco.Municipio
            };
        }

        public static List<EnderecoViewModel> ToListViewModel(IEnumerable<Endereco> enderecos)
        {
            var list = new List<EnderecoViewModel>();
            foreach (var endereco in enderecos)
                list.Add(ToViewModel(endereco));

            return list;
        }
    }
}
