using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.Atas
{
    public class DeleteAta
    {
        private readonly IAtaRepository _ataRepository;

        public DeleteAta(IAtaRepository ataRepository)
        {
            _ataRepository = ataRepository;
        }

        public async Task Run(Ata ata)
        {
            await _ataRepository.Delete(ata);
        }
    }
}
