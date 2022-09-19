using Domain.Entities;
using Domain.IRepositories;
using System;
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

        public async Task<DetentoraItem> GetByIds(Guid detentoraId, Guid itemId)
        {
            return await _detentoraItemRepository.GetByIds(detentoraId, itemId);
        }

        public async Task<DetentoraItem> GetByItemId(Guid itemId)
        {
            return await _detentoraItemRepository.GetByItemId(itemId);
        }

        public async Task<DetentoraItem> GetById(Guid detentoraItemId)
        {
            return await _detentoraItemRepository.GetByPrimaryKey(detentoraItemId);
        }

        public async Task<IEnumerable<DetentoraItem>> GetListDetentoraByAta(int yearAta, int codeAta)
        {
            return await _detentoraItemRepository.GetListDetentoraByAta(yearAta, codeAta);
        }
    }
}
