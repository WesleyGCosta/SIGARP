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

        public static ItemViewModel ToViewModel(Item item)
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
                QuantidadeDisponivel = item.QuantidadeDisponivel,
                PrecoMercado = item.PrecoMercado,
                PrecoRegistrado = item.PrecoRegistrado,
                Ativo = item.Ativo
            };

            if (item.DetentoraItem != null)
                itemViewModel.ItemDetentora = ItemDetentoraFactory.ToViewModel(item.DetentoraItem);

            if (item.ParticipantesItens != null && item.ParticipantesItens.Any())
                itemViewModel.ParticipanteItems = ParticipanteItemFactory.ToListViewModel(item.ParticipantesItens);
            
            return itemViewModel;
        }

        public static List<ItemViewModel> ToListViewModel(IEnumerable<Item> itens)
        {
            var list = new List<ItemViewModel>();
            foreach (var item in itens)
                list.Add(ToViewModel(item));

            return list;
        }
    }
}
