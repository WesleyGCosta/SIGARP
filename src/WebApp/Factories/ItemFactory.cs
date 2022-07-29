using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class ItemFactory
    {
        public static Item ToEntityItem(ItemViewModel itemViewModel)
        {
            return new Item(
                itemViewModel.Id,
                itemViewModel.CodigoItem,
                itemViewModel.CodigoAta,
                itemViewModel.AnoAta,
                itemViewModel.Tipo,
                itemViewModel.Descricao,
                itemViewModel.Marca,
                itemViewModel.UnidadeAquisicao,
                itemViewModel.ConsumoEstimado,
                itemViewModel.PrecoMercado,
                itemViewModel.PrecoRegistrado,
                itemViewModel.Ativo
                );
        }
    }
}
