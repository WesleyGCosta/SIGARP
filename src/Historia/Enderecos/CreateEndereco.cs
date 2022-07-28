using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.Enderecos
{
    public class CreateEndereco
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public CreateEndereco(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task Run(Endereco endereco)
        {
            await _enderecoRepository.Create(endereco);
        }
    }
}
