using Domain.Entities;
using System;

namespace Domain.Entities
{
    public class DetentoraItem
    {
        public DetentoraItem(Guid id, Guid itemId, Guid detentoraId)
        {
            Id = id;
            ItemId = itemId;
            DetentoraId = detentoraId;
        }

        public Guid Id { get; private set; }
        public Guid ItemId { get; private set; }
        public Guid DetentoraId { get; private set; }

        public Item Item { get; private set; }
        public Detentora Detentora { get; private set; }
    }
}
