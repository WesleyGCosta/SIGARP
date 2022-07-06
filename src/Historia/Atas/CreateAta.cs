using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.Atas
{
    public class CreateAta
    {
        private readonly IAtaRepository _ataRepository;

        public CreateAta(IAtaRepository ataRepository)
        {
            _ataRepository = ataRepository;
        }

        public async Task Run(Ata ata)
        {
            await _ataRepository.Create(ata);
        }
    }
}
