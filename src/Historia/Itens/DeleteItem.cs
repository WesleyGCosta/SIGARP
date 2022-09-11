using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Threading.Tasks;

namespace Historia.Itens
{
    public class DeleteItem
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItem(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task Run(Item item)
        {
            await _itemRepository.Delete(item);
        }
    }
}
