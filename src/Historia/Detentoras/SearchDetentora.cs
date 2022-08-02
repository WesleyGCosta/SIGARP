using Domain.Entities;
using Domain.IRepositories;
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

        public async Task<List<Detentora>> GetAll()
        {
            return await _detentoraRepository.GetAll();
        }
    }
}
