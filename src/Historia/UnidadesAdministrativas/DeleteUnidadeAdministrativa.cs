using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia.UnidadesAdministrativas
{
    public class DeleteUnidadeAdministrativa
    {
        private readonly IUnidadeAdministrativaRepository _unidadeAdministrativaRepository;

        public DeleteUnidadeAdministrativa(IUnidadeAdministrativaRepository unidadeAdministrativaRepository)
        {
            _unidadeAdministrativaRepository = unidadeAdministrativaRepository;
        }

        public async Task Run(UnidadeAdministrativa unidadeAdministrativa)
        {
            await _unidadeAdministrativaRepository.Delete(unidadeAdministrativa);
        }
    }
}
