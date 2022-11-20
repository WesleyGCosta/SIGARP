using Domain.Entities;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class OrdemForncecimentoFactory
    {
        public static OrdemFornecimentoViewModel ToViewModel(OrdemFornecimento ordemFornecimento)
        {
            return new OrdemFornecimentoViewModel
            {
                Id= ordemFornecimento.Id,
                ProgramacaoConsumoId = ordemFornecimento.ProgramacaoConsumoParticipanteId,
                DataFornecimento = ordemFornecimento.DataFornecimento,
                NumeroProcesso = ordemFornecimento.NumeroProcesso,
                Consumo = ordemFornecimento.Consumo
            };
        }

        public static OrdemFornecimento ToEntity(OrdemFornecimentoViewModel ordemFornecimento)
        {
            return new OrdemFornecimento(
                ordemFornecimento.Id,
                ordemFornecimento.ProgramacaoConsumoId,
                ordemFornecimento.DataFornecimento,
                ordemFornecimento.NumeroProcesso,
                ordemFornecimento.Consumo
                );
        }

        public static ICollection<OrdemFornecimentoViewModel> ToListViewModel(ICollection<OrdemFornecimento> ordemFornecimentoCollection)
        {
            var list = new List<OrdemFornecimentoViewModel>();
            foreach(var fornecimento in ordemFornecimentoCollection)
            {
                list.Add(ToViewModel(fornecimento));
            }

            return list;
        }
    }
}
