using Domain.Entities;
using Domain.IRepositories;
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

        public async Task<Item> GetItemByCodeAtaAndYearAta(int yearAta, int codeAta, int codeItem)
        {
            return await _itemRepository.GetItemByCodeAtaAndYearAta(yearAta, codeAta, codeItem);
        }

        public async Task<Item> GetLastItemByCodeAtaAndYearAta(int year, int code)
        {
            return await _itemRepository.GetLastItemByCodeAtaAndYearAta(year, code);
        }

        public async Task<List<Item>> GetListItemByCodeAtaAndYearAta(int year, int code)
        {
            return await _itemRepository.GetListItemByCodeAtaAndYearAta(year, code);
        }

        public async Task<List<Item>> GetListItemWithDetentora(int year, int code)
        {
            return await _itemRepository.GetListItemWithDetentora(year, code);
        }
    }
}
