using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.Itens
{
    public class CreateItem
    {
        private readonly IItemRepository _itemRepository;

        public CreateItem(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task Run(Item item)
        {
            item.SetQuantidadeAvailable();
            await _itemRepository.Create(item);
        }
    }
}
