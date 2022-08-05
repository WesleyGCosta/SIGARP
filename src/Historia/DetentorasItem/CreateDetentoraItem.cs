﻿using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.DetentorasItem
{
    public class CreateDetentoraItem
    {
        private readonly IDetentoraItemRepository _detentoraItemRepository;

        public CreateDetentoraItem(IDetentoraItemRepository detentoraItemRepository)
        {
            _detentoraItemRepository = detentoraItemRepository;
        }

        public async Task Run(List<DetentoraItem> detentorasItem)
        {
            foreach(var detentoraItem in detentorasItem)
                await _detentoraItemRepository.Create(detentoraItem);
        }
    }
}