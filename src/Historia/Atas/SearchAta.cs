using Domain.Dtos;
using Domain.Entities;
using Domain.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historia.Atas
{
    public class SearchAta
    {
        private readonly IAtaRepository _ataRepository;

        public SearchAta(IAtaRepository ataRepository)
        {
            _ataRepository = ataRepository;
        }

        public async Task<List<AtaYearDto>> GetAtasCountByYear(List<int> years)
        {
            return await _ataRepository.GetAtasCountByYear(years);
        }

        public async Task<List<AtaMonthDto>> GetAtasCountByMonths()
        {
            return await _ataRepository.GetAtasCountByMonth();
        }

        public async Task<Ata> GetAtaByYear(int year)
        {
            return await _ataRepository.GetByYear(year);
        }

        public async Task<Ata> GetAtaByYearAndCode(int year, int code)
        {
            return await _ataRepository.GetAtaByYearAndCode(year, code);
        }

        public async Task<List<Ata>> GetListAtaByYear(int year)
        {
            return await _ataRepository.GetListAtaByYear(year);
        }

        public async Task<Ata> GetAtaFullIncludeByYearAndCode(int year, int code)
        {
            return await _ataRepository.GetAtaFullIncludeByYearAndCode(year, code);
        }
        public async Task<List<int>> GetListCodeByYear(int year)
        {
            return await _ataRepository.GetListCodeByYear(year);
        }

        public async Task<int> CountAtasByPublish(bool publish)
        {
            return await _ataRepository.CountAtasByPublish(publish);
        }
    }
}
