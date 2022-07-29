using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IAtaRepository : IBaseRepository<Ata> 
    {
        Task<Ata> GetByYear(int year);
        Task<List<int>> GetListCodeByYear(int year);
    }
}
