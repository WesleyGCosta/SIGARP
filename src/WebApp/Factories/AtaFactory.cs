using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class AtaFactory
    {
        public static Ata ToEntityAta(AtaViewModel ataViewModel)
        {
            var ata = new Ata(
                ataViewModel.NumeroAta,
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
    }
}
