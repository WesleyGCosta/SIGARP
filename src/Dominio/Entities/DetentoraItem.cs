﻿using Domain.Entities;
using System;

namespace Domain.Entities
{
    public class DetentoraItem
    {
        public Guid Id { get; private set; }
        public Guid ItemId { get; private set; }
        public Guid DetentoraId { get; private set; }

        public Item Item { get; private set; }
        public Detentora Detentora { get; private set; }
    }
}