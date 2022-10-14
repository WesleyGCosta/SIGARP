using Domain.Entities;
using Domain.IRepositories;
using System;
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

        public async Task<bool> Run(Guid id, bool status)
        {
            var detentoraConsult = await _detentoraRepository.GetByPrimaryKey(id);

            if (detentoraConsult == null)
                return false;

            detentoraConsult.UpdateStatus(status);
            await _detentoraRepository.Update(detentoraConsult);

            return true;
        }
    }
}
