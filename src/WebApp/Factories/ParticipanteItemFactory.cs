using Domain.Entities;
using System;
using System.Collections.Generic;
using WebApp.ViewModels;

namespace WebApp.Factories
{
    public static class ParticipanteItemFactory
    {
        public static ParticipanteItem ToEntity(Guid participanteId, Guid itemId, Guid unidadeAdministrativaId)
        {
            return new ParticipanteItem(participanteId, itemId, unidadeAdministrativaId);
        }

        public static ParticipanteItemViewModel ToViewModel(ParticipanteItem participanteItem)
        {
            participanteItem.Item.SetNullIncludes();
            return new ParticipanteItemViewModel
            {
                Id = participanteItem.Id,
                UnidadeAdministrativaId = participanteItem.UnidadeAdministrativaId,
                ItemId = participanteItem.ItemId,
                ItemViewModel = ItemFactory.ToViewModel(participanteItem.Item),
                UnidadeAdministrativaViewModel = UnidadeAdministrativaFactory.ToViewModel(participanteItem.UnidadeAdministrativa),
            };
        }

        public static List<ParticipanteItemViewModel> ToListViewModel(IEnumerable<Item> itens)
        {
            var list = new List<ParticipanteItemViewModel>();
            foreach (var item in itens)
                list.AddRange(ToListViewModel(item.ParticipantesItens));

            return list;
        }

        public static List<ParticipanteItemViewModel> ToListViewModel(IEnumerable<ParticipanteItem> participanteItems)
        {
            var list = new List<ParticipanteItemViewModel>();
            foreach (var item in participanteItems)
                list.Add(ToViewModel(item));

            return list;
        }
    }
}
