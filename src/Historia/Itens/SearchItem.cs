using Domain.Entities;
using Domain.IRepositories;
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

        public async Task<Item> GetLastItemByCodeAtaAndYearAta(int year, int code)
        {
            return await _itemRepository.GetLastItemByCodeAtaAndYearAta(year, code);
        }
    }
}
