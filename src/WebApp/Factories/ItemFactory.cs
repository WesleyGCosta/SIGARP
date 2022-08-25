using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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
                itemViewModel.Quantidade,
                itemViewModel.QuantidadeDisponivel,
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
                Quantidade = item.Quantidade,
                PrecoMercado = item.PrecoMercado,
                PrecoRegistrado = item.PrecoRegistrado,
                Ativo = item.Ativo
            };
            if (item.DetentoraItem != null)
                itemViewModel.Detentora = DetentoraFactory.ToDetentoraViewModel(item.DetentoraItem.Detentora);
            if (item.ParticipantesItens != null)
                itemViewModel.UnidadeAdministrativa = UnidadeAdministrativaFactory.ToListViewMode(item.ParticipantesItens.Select(pt => pt.UnidadeAdministrativa));

            return itemViewModel;
        }

        public static List<ItemViewModel> ToListItemViewModel(IEnumerable<Item> itens)
        {
            var list = new List<ItemViewModel>();
            foreach(var item in itens)
                list.Add(ToItemViewModel(item));

            return list;
        }
    }
}
