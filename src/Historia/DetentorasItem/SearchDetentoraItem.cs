using Domain.Entities;
using Domain.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historia.DetentorasItem
{
    public class SearchDetentoraItem
    {
        private readonly IDetentoraItemRepository _detentoraItemRepository;

        public SearchDetentoraItem(IDetentoraItemRepository detentoraItemRepository)
        {
            _detentoraItemRepository = detentoraItemRepository;
        }

        public async Task<List<DetentoraItem>> GetAll()
        {
            return await _detentoraItemRepository.GetAll();
        }
    }
}
