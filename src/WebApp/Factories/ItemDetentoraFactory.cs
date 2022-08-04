using Domain.Entities;
using System;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class ItemDetentoraFactory
    {
        public static DetentoraItem ToEntityDetentoraItem(Guid idDetentora, Guid idItem)
        {
            var detentoraItem = new DetentoraItem(
                itemId: idItem,
                detentoraId: idDetentora
                );

            return detentoraItem;
        }

        public static List<DetentoraItem> ToListEntityDetentoraItem(ItemDetentoraViewModel itemDetentoraViewModel)
        {
            var list = new List<DetentoraItem>();
            foreach(var guidItem in itemDetentoraViewModel.CodigoItem)
            {
                list.Add(ToEntityDetentoraItem(itemDetentoraViewModel.CodigoDetentora, guidItem));
            }

            return list;
        }
    }
}
