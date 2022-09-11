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

        public async Task<bool> Run(int yearAta, int codeAta)
        {
            var ata = await _ataRepository.GetAtaByYearAndCode(yearAta, codeAta);
            if (ata.Equals(null))
                return false;

            await _ataRepository.Delete(ata);
            return true;
        }
    }
}
