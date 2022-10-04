using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historia.Itens
{
    public class SearchItem
    {
        private readonly IItemRepository _itemRepository;

        public SearchItem(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Item> GetById(Guid itemId)
        {
            return await _itemRepository.GetByPrimaryKey(itemId);
        }
        public async Task<Item> GetByParticipanteId(Guid participanteId)
        {
            return await _itemRepository.GetByParticipanteId(participanteId);
        }


        public async Task<Item> GetByIdInclude(Guid itemId)
        {
            return await _itemRepository.GetByIdInclude(itemId);
        }

        public async Task<Item> GetItemByCodeAtaAndYearAta(int yearAta, int codeAta, int codeItem)
        {
            return await _itemRepository.GetItemByCodeAtaAndYearAta(yearAta, codeAta, codeItem);
        }

        public async Task<List<Item>> GetListItemByCodeAtaAndYearAta(int year, int code)
        {
            return await _itemRepository.GetListItemByCodeAtaAndYearAta(year, code);
        }

        public async Task<List<Item>> GetListItemByCodeAtaAndYearAtaIncludeDetentora(int year, int code)
        {
            return await _itemRepository.GetListItemByCodeAtaAndYearAtaIncludeDetentora(year, code);
        }

        public async Task<Item> GetItemByCodeAtaAndYearAtaIncludeUnidadeAdministrativa(int year, int code, int codeItem)
        {
            return await _itemRepository.GetItemByCodeAtaAndYearAtaIncludeUnidadeAdministrativa(year, code, codeItem);
        }

        public async Task<List<Item>> GetItemByCodeAtaAndYearAtaIncludeParticipantes(int year, int code)
        {
            return await _itemRepository.GetItemByCodeAtaAndYearAtaIncludeParticipantes(year, code);
        }

        public async Task<List<Item>> GetListItemWithDetentora(int year, int code)
        {
            return await _itemRepository.GetListItemWithDetentora(year, code);
        }
    }
}
