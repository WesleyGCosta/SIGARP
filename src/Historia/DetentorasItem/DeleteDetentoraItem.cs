using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.DetentorasItem
{
    public class DeleteDetentoraItem
    {
        private readonly IDetentoraItemRepository _detentoraItemRepository;

        public DeleteDetentoraItem(IDetentoraItemRepository detentoraItemRepository)
        {
            _detentoraItemRepository = detentoraItemRepository;
        }

        public async Task Run(DetentoraItem detentoraItem)
        {
            await _detentoraItemRepository.Delete(detentoraItem);
        }
    }
}
