using Domain.Entities;
using System.Collections.Generic;
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

        public static ItemViewModel ToItemViewModel(Item item)
        {
            var itemViewModel = new ItemViewModel 
            {
                Id = item.Id,
                CodigoItem = item.NumeroItem,
                AnoAta = item.AnoAta,
                CodigoAta = item.CodigoAta,
                Tipo = item.Tipo,
                Descricao = item.Descricao,
                Marca = item.Marca,
                UnidadeAquisicao = item.UnidadeAquisicao,
                ConsumoEstimado = item.ConsumoEstimado,
                PrecoMercado = item.PrecoMercado,
                PrecoRegistrado = item.PrecoRegistrado,
                Ativo = item.Ativo
            };
            if (item.DetentoraItem != null)
                itemViewModel.Detentora = DetentoraFactory.ToDetentoraViewModel(item.DetentoraItem.Detentora);

            return itemViewModel;
        }

        public static List<ItemViewModel> ToListItemViewModel(List<Item> itens)
        {
            var list = new List<ItemViewModel>();
            foreach(var item in itens)
                list.Add(ToItemViewModel(item));

            return list;
        }
    }
}
