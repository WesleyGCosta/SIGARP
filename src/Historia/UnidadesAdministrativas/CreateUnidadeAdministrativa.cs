using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.UnidadesAdministrativas
{
    public class CreateUnidadeAdministrativa
    {
        private readonly IUnidadeAdministrativaRepository _unidadeAdministrativaRepository;

        public CreateUnidadeAdministrativa(IUnidadeAdministrativaRepository unidadeAdministrativaRepository)
        {
            _unidadeAdministrativaRepository = unidadeAdministrativaRepository;
        }

        public async Task Run(UnidadeAdministrativa unidadeAdministrativa)
        {
            await _unidadeAdministrativaRepository.Create(unidadeAdministrativa);
        }
    }
}
