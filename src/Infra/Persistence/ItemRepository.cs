﻿using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(DataContext db) : base(db)
        {
        }

        public async Task<Item> GetItemByCodeAtaAndYearAta(int yearAta, int codeAta, int codeItem)
        {
            return await _db.Itens
                .AsNoTracking()
                .Where(i => i.CodigoAta.Equals(codeAta) && i.AnoAta.Equals(yearAta) && i.NumeroItem.Equals(codeItem))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetListItemByCodeAtaAndYearAta(int year, int code)
        {
            return await _db.Itens
                .AsNoTracking()
                .Where(i => i.CodigoAta.Equals(code) && i.AnoAta.Equals(year))
                .OrderBy(i => i.NumeroItem)
                .ToListAsync();
        }

        public async Task<List<Item>> GetListItemByCodeAtaAndYearAtaIncludeDetentora(int year, int code)
        {
            return await _db.Itens
                .AsNoTracking()
                .Include(i => i.DetentoraItem)
                .ThenInclude(di => di.Detentora)
                .Where(i => i.CodigoAta.Equals(code) && i.AnoAta.Equals(year))
                .OrderBy(i => i.NumeroItem)
                .ToListAsync();
        }

        public async Task<List<Item>> GetListItemWithDetentora(int year, int code)
        {
            return await _db.Itens
                .AsNoTracking()
                .Include(i => i.DetentoraItem)
                .ThenInclude(di => di.Detentora)
                .Where(i => i.AnoAta.Equals(year) && i.CodigoAta.Equals(code) && i.DetentoraItem != null)
                .OrderBy(i => i.NumeroItem)
                .ToListAsync();
        }
    }
}