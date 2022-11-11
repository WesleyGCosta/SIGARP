using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.OrdensFornecimentos
{
    public class CreateOrdemFornecimento
    {
        private readonly IOrdemFornecimentoRepository _ordemFornecimentoRepositoryrepository;

        public CreateOrdemFornecimento(IOrdemFornecimentoRepository ordemFornecimentoRepositoryrepository)
        {
            _ordemFornecimentoRepositoryrepository = ordemFornecimentoRepositoryrepository;
        }

        public async Task Run(OrdemFornecimento ordemFornecimento)
        {
            await _ordemFornecimentoRepositoryrepository.Create(ordemFornecimento);
        }
    }
}
