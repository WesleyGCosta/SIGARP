using Domain.Entities;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Historia.Atas
{
    public class UpdateAta
    {
        private readonly IAtaRepository _ataRepository;

        public UpdateAta(IAtaRepository ataRepository)
        {
            _ataRepository = ataRepository;
        }

        public async Task Edit(Ata ataUpdate)
        {
            var ataConsult = await _ataRepository.GetAtaByYearAndCode(ataUpdate.AnoAta, ataUpdate.CodigoAta);
            ataConsult.Update(ataUpdate);
            await _ataRepository.Update(ataConsult);
        }

        public async Task Publish(int codeAta, int yearAta)
        {
            var ataPublish = await _ataRepository.GetAtaByYearAndCode(yearAta, codeAta);
            ataPublish.Publish();
            await _ataRepository.Update(ataPublish);
        }

        public async Task Rectify(Ata ataPublish)
        {
            ataPublish.Rectify();
            await _ataRepository.Update(ataPublish);
        }
    }
}
