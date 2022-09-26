using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.Enderecos
{
    public class UpdateEndereco
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public UpdateEndereco(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task Run(Endereco endereco)
        {
            var enderecoConsult = await _enderecoRepository.GetByPrimaryKey(endereco.Id);

            enderecoConsult.Udpate(endereco);
            await _enderecoRepository.Update(enderecoConsult);
        }
    }
}
