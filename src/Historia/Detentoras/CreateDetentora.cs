using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.Detentoras
{
    public class CreateDetentora
    {
        private readonly IDetentoraRepository _detentoraRepository;

        public CreateDetentora(IDetentoraRepository detentoraRepository)
        {
            _detentoraRepository = detentoraRepository;
        }

        public async Task Run(Detentora detentora)
        {
            await _detentoraRepository.Create(detentora);
        }
    }
}
