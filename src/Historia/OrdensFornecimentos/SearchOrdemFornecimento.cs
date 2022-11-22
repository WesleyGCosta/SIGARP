using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Threading.Tasks;

namespace Historia.OrdensFornecimentos
{
    public class SearchOrdemFornecimento
    {
        private readonly IOrdemFornecimentoRepository _ordemFornecimentoRepositoryrepository;

        public SearchOrdemFornecimento(IOrdemFornecimentoRepository ordemFornecimentoRepositoryrepository)
        {
            _ordemFornecimentoRepositoryrepository = ordemFornecimentoRepositoryrepository;
        }

        public async Task<OrdemFornecimento> GetOrdemFornecimentoId(Guid id)
        {
            return await _ordemFornecimentoRepositoryrepository.GetByPrimaryKey(id);
        }
    }
}
