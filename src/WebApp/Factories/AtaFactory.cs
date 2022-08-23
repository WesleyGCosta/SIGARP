using Domain.Entities;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class AtaFactory
    {
        public static Ata ToEntityAta(AtaViewModel ataViewModel)
        {
            var ata = new Ata(
                ataViewModel.CodigoAta,
                ataViewModel.AnoAta,
                ataViewModel.NumeroProcesso,
                ataViewModel.NumeroPregao,
                ataViewModel.AnoPregao,
                ataViewModel.TipoPregao,
                ataViewModel.DataHomologacao,
                ataViewModel.DataPublicacaoDOE,
                ataViewModel.DataFinalVigencia,
                ataViewModel.ObjetoResumido,
                ataViewModel.Publicada,
                ataViewModel.DataPublicacaoSistema,
                ataViewModel.DataCadastro,
                ataViewModel.DataAlteracao,
                ataViewModel.Observacao,
                ataViewModel.LimiteAdesao
                );

            return ata;
        }

        public static AtaViewModel ToViewModel(Ata ata)
        {
            var ataViewModel = new AtaViewModel
            {
                CodigoAta = ata.CodigoAta,
                AnoAta = ata.AnoAta,
                NumeroProcesso = ata.NumeroProcesso,
                NumeroPregao = ata.NumeroPregao,
                TipoPregao = ata.TipoPregao,
                DataHomologacao = ata.DataHomologacao,
                DataPublicacaoDOE = ata.DataPublicacaoDOE,
                DataFinalVigencia = ata.DataFinalVigencia,
                DataPublicacaoSistema = ata.DataPublicacaoSistema,
                DataCadastro = ata.DataCadastro,
                DataAlteracao = ata.DataAlteracao
            };
            if (ata.Itens != null)
                ataViewModel.ItensViewModel = ItemFactory.ToListItemViewModel(ata.Itens);

            return ataViewModel;
        }

        public static List<AtaViewModel> ToListViewModel(IEnumerable<Ata> atas)
        {
            var list = new List<AtaViewModel>();
            foreach (var ata in atas)
                list.Add(ToViewModel(ata));

            return list;
        }
    }
}
