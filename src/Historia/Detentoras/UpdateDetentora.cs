using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.Detentoras
{
    public class UpdateDetentora
    {
        private readonly IDetentoraRepository _detentoraRepository;

        public UpdateDetentora(IDetentoraRepository detentoraRepository)
        {
            _detentoraRepository = detentoraRepository;
        }

        public async Task Run(Detentora detentora)
        {
            var detentoraConsult = await _detentoraRepository.GetByPrimaryKey(detentora.Id);

            detentoraConsult.Update(detentora);
            await _detentoraRepository.Update(detentoraConsult);
        }
    }
}
