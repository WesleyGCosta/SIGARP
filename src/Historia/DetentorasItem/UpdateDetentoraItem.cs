using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.DetentorasItem
{
    public class UpdateDetentoraItem
    {
        private readonly IDetentoraItemRepository _detentoraItemRepository;

        public UpdateDetentoraItem(IDetentoraItemRepository detentoraItemRepository)
        {
            _detentoraItemRepository = detentoraItemRepository;
        }

        public async Task Run(DetentoraItem detentoraItem)
        {
            var detentoraItemConsult = await _detentoraItemRepository.GetByItemId(detentoraItem.ItemId);

            detentoraItemConsult.Update(detentoraItem);
            await _detentoraItemRepository.Update(detentoraItemConsult);
        }
    }
}
