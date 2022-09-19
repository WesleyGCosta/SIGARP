using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.Itens
{
    public class UpdateItem
    {
        private readonly IItemRepository _itemRepository;

        public UpdateItem(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task Run(Item item)
        {
            var itemConsult = await _itemRepository.GetByPrimaryKey(item.Id);

            itemConsult.Update(item);
            await _itemRepository.Update(itemConsult);
        }
    }
}
