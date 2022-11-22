using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.OrdensFornecimentos
{
    public class DeleteOrdemFornecimento
    {
        private readonly IOrdemFornecimentoRepository _ordemFornecimentoRepository;

        public DeleteOrdemFornecimento(IOrdemFornecimentoRepository ordemFornecimentoRepository)
        {
            _ordemFornecimentoRepository = ordemFornecimentoRepository;
        }

        public async Task Run(OrdemFornecimento fornecimento)
        {
            await _ordemFornecimentoRepository.Delete(fornecimento);
        }
    }
}
