using Domain.Entities;
using System;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class ItemDetentoraFactory
    {
        public static DetentoraItem ToEntity(Guid idDetentora, Guid idItem)
        {
            var detentoraItem = new DetentoraItem(
                itemId: idItem,
                detentoraId: idDetentora
                );

            return detentoraItem;
        }

        public static ItemDetentoraViewModel ToViewModel(DetentoraItem detentoraItem)
        {
            return new ItemDetentoraViewModel
            {
                Id = detentoraItem.Id,
                CodigoDetentora = detentoraItem.DetentoraId,
                CodigoItem = detentoraItem.ItemId,
                Detentora = DetentoraFactory.ToDetentoraViewModel(detentoraItem.Detentora),
            };
        }

        public static List<ItemDetentoraViewModel> ToListViewModel(IEnumerable<Item> Itens)
        {
            var list = new List<ItemDetentoraViewModel>();
            foreach (var item in Itens)
                list.Add(ToViewModel(item.DetentoraItem));

            return list;
        }

        public static IList<ItemDetentoraViewModel> ToListViewModel(IEnumerable<DetentoraItem> detentorasItens)
        {
            var list = new List<ItemDetentoraViewModel>();
            foreach (var item in detentorasItens)
                list.Add(ToViewModel(item));

            return list;
        }
    }
}
