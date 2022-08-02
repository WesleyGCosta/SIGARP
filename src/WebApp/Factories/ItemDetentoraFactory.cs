using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class ItemDetentoraFactory
    {
        public static DetentoraItem ToEntityDetentoraItem(ItemDetentoraViewModel itemDetentoraViewModel)
        {
            var detentoraItem = new DetentoraItem(
                itemDetentoraViewModel.Id,
                itemDetentoraViewModel.CodigoItem,
                itemDetentoraViewModel.CodigoDetentora
                );

            return detentoraItem;
        }
    }
}
