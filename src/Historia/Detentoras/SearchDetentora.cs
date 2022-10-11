using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historia.Detentoras
{
    public class SearchDetentora
    {
        private readonly IDetentoraRepository _detentoraRepository;

        public SearchDetentora(IDetentoraRepository detentoraRepository)
        {
            _detentoraRepository = detentoraRepository;
        }

        public async Task<Detentora> GetById(Guid id)
        {
            return await _detentoraRepository.GetIdInclude(id);
        }

        public async Task<List<Detentora>> GetByStatus(bool status)
        {
            return await _detentoraRepository.GetByStatus(status);
        }

        public async Task<List<Detentora>> GetAll()
        {
            return await _detentoraRepository.GetAll();
        }

        public async Task<Detentora> GetByCnpj(string cnpj)
        {
            return await _detentoraRepository.GetByCnpj(cnpj);
        }

        public async Task<List<Detentora>> GetListDetentoraItemByAta(int yearAta, int codeAta)
        {
            return await _detentoraRepository.GetListDetentoraItemByAta(yearAta, codeAta);
        }

        public async Task<int> CountDetentoras()
        {
            return await _detentoraRepository.CountDetentoras();
        }
    }
}
