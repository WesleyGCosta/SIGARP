using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.RealinhamentosPrecos
{
    public class CreateRealinhamentoPreco
    {
        private readonly IRealinhamentoPrecoRepository _realinhamentoPrecoRepository;

        public CreateRealinhamentoPreco(IRealinhamentoPrecoRepository realinhamentoPrecoRepository)
        {
            _realinhamentoPrecoRepository = realinhamentoPrecoRepository;
        }

        public async Task Run(RealinhamentoPreco realinhamentoPreco)
        {
            await _realinhamentoPrecoRepository.Create(realinhamentoPreco);
        }
    }
}
