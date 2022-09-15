using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IDetentoraItemRepository : IBaseRepository<DetentoraItem>
    {
        Task<DetentoraItem> GetByIds(Guid detentoraId, Guid itemId);
        Task<List<DetentoraItem>> GetListDetentoraByAta(int yearAta, int codeAta);
    }
}
