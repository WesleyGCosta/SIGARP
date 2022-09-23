using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IDetentoraRepository : IBaseRepository<Detentora>
    {
        Task<List<Detentora>> GetListDetentoraItemByAta(int yearAta, int codeAta);
        Task<Detentora> GetByCnpj(string cnpj);
        Task<Detentora> GetIdInclude(Guid id);
    }
}
