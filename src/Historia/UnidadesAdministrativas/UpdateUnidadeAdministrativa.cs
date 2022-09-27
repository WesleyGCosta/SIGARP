using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.UnidadesAdministrativas
{
    public class UpdateUnidadeAdministrativa
    {
        private readonly IUnidadeAdministrativaRepository _unidadeAdministrativaRepository;

        public UpdateUnidadeAdministrativa(IUnidadeAdministrativaRepository unidadeAdministrativaRepository)
        {
            _unidadeAdministrativaRepository = unidadeAdministrativaRepository;
        }

        public async Task Run(UnidadeAdministrativa unidadeAdministrativa)
        {
            var unidadeAdministrativaConsult = await _unidadeAdministrativaRepository.GetByPrimaryKey(unidadeAdministrativa.Id);
            unidadeAdministrativaConsult.Update(unidadeAdministrativa);
            await _unidadeAdministrativaRepository.Update(unidadeAdministrativaConsult);

        }
    }
}
