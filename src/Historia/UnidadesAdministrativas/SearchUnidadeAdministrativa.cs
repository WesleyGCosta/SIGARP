using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historia.UnidadesAdministrativas
{
    public class SearchUnidadeAdministrativa
    {
        private readonly IUnidadeAdministrativaRepository _unidadeAdministrativaRepository;

        public SearchUnidadeAdministrativa(IUnidadeAdministrativaRepository unidadeAdministrativaRepository)
        {
            _unidadeAdministrativaRepository = unidadeAdministrativaRepository;
        }

        public async Task<ICollection<UnidadeAdministrativa>> GetAll()
        {
            return await _unidadeAdministrativaRepository.GetAll();
        }

        public async Task<UnidadeAdministrativa> GetById(Guid unidadeAdministrativaId)
        {
            return await _unidadeAdministrativaRepository.GetByPrimaryKey(unidadeAdministrativaId);
        }

        public async Task<UnidadeAdministrativa> GetBySigla(string sigla)
        {
            return await _unidadeAdministrativaRepository.GetBySigla(sigla);
        }

        public async Task<int> CountUnidadesAdministrativas()
        {
            return await _unidadeAdministrativaRepository.CountAll();
        }
    }
}
