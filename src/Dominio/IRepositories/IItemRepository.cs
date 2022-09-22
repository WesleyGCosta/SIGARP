using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<Item> GetByIdInclude(Guid id);
        Task<Item> GetItemByCodeAtaAndYearAta(int yearAta, int codeAta, int codeItem);
        Task<List<Item>> GetListItemByCodeAtaAndYearAta(int yearAta, int codeAta);
        Task<List<Item>> GetListItemByCodeAtaAndYearAtaIncludeDetentora(int yearAta, int codeAta);
        Task<List<Item>> GetItemByCodeAtaAndYearAtaIncludeParticipantes(int yearAta, int codeAta);
        Task<Item> GetItemByCodeAtaAndYearAtaIncludeUnidadeAdministrativa(int yearAta, int codeAta, int codeItem);
       
        Task<List<Item>> GetListItemWithDetentora(int year, int code);
    }
}
