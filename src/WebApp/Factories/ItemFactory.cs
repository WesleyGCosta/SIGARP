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
            itemViewModel.UpdateQuantidadeDisponivel();
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
                QuantidadeSalvoDbo = item.Quantidade,
                PrecoMercado = item.PrecoMercado,
                PrecoRegistrado = item.PrecoRegistrado,
                Ativo = item.Ativo
            };

            if(item.Ata != null)
            {
                itemViewModel.DataVirgencia = item.Ata.DataVencimentoAta;
            }

            if (item.DetentoraItem != null)
            {
                itemViewModel.ItemDetentora = ItemDetentoraFactory.ToViewModel(item.DetentoraItem);
                itemViewModel.ItemDetentora.Item = itemViewModel;
            }

            if (item.ParticipantesItens != null && item.ParticipantesItens.Any())
            {
                itemViewModel.ParticipanteItems = ParticipanteItemFactory.ToListViewModel(item.ParticipantesItens);
                foreach (var participante in itemViewModel.ParticipanteItems)
                    participante.ItemViewModel = itemViewModel;
            }
                           
            return itemViewModel;
        }

        public static List<ItemViewModel> ToListViewModel(IEnumerable<Item> itens)
        {
            var list = new List<ItemViewModel>();
            foreach (var item in itens)
                list.Add(ToViewModel(item));

            return list;
        }

        public static List<ItemViewModel> ToListViewModel(IEnumerable<ParticipanteItem> participantes)
        {
            var list = new List<ItemViewModel>();
            foreach (var participante in participantes)
                list.Add(ToViewModel(participante.Item));

            return list;
        }
    }
}
