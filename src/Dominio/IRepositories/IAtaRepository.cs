using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IAtaRepository : IBaseRepository<Ata> 
    {
        Task<Ata> GetByYear(int year);
    }
}
