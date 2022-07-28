using Domain.Entities;
using System;
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
    }
}
