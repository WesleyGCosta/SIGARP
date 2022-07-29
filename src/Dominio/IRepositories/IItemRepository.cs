using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<Item> GetLastItemByCodeAtaAndYearAta(int year, int code);
    }
}
