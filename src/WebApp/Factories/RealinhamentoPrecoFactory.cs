using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class RealinhamentoPrecoFactory
    {
        public static RealinhamentoPreco ToEntity(RealinhamentoPrecoViewModel realinhamento)
        {
            return new RealinhamentoPreco(
                realinhamento.Id,
                realinhamento.ItemId,
                realinhamento.DataRegistro,
                realinhamento.PrecoMercado,
                realinhamento.PrecoRegistrado,
                realinhamento.PrecoAtual,
                realinhamento.Justificativa,
                realinhamento.PrecoMercadoAnterior,
                realinhamento.PrecoRegistradoAnterior,
                realinhamento.Usuario);
        }
    }
}
