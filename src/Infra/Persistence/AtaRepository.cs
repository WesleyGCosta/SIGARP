using Domain.Dtos;
using Domain.Entities;
using Domain.IRepositories;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    public class AtaRepository : BaseRepository<Ata>, IAtaRepository
    {
        public AtaRepository(DataContext db) : base(db)
        {
        }

        public async Task<Ata> GetAtaByYearAndCode(int year, int code)
        {
            return await _db.Atas
                .AsNoTracking()
                .Where(a => a.AnoAta.Equals(year) && a.CodigoAta.Equals(code) && a.Publicada.Equals(false))
                .FirstOrDefaultAsync();
        }

        public async Task<Ata> GetByYear(int year)
        {
            return await _db.Atas
                .AsNoTracking()
                .Where(a => a.AnoAta.Equals(year))
                .OrderByDescending(a => a.CodigoAta)
                .FirstOrDefaultAsync();
        }

        public async Task<Ata> GetAtaFullIncludeByYearAndCode(int year, int code)
        {
            return await _db.Atas
                .AsNoTracking()
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                    .ThenInclude(i => i.DetentoraItem)
                    .ThenInclude(d => d.Detentora)
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                    .ThenInclude(i => i.ParticipantesItens)
                    .ThenInclude(pt => pt.UnidadeAdministrativa)
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                    .ThenInclude(i => i.ParticipantesItens)
                    .ThenInclude(pt => pt.ProgramacoesConsumoParticipantes)
                .Where(a => a.AnoAta.Equals(year) && a.CodigoAta.Equals(code))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Ata>> GetListAtaByYear(int year)
        {
            return await _db.Atas
                .Where(a => a.AnoAta.Equals(year))
                .OrderBy(a => a.CodigoAta)
                .ToListAsync();
        }

        public async Task<List<int>> GetListCodeByYearPublish(int year, bool publish)
        {
            return await _db.Atas
                .AsNoTracking()
                .Where(a => a.AnoAta.Equals(year) && a.Publicada.Equals(publish))
                .Select(a => a.CodigoAta)
                .ToListAsync();
        }

        public async Task<int> CountAtasByPublish(bool publish)
        {
            return await _db.Atas
                 .AsNoTracking()
                 .Where(a => a.Publicada.Equals(publish))
                 .CountAsync();
        }

        public async Task<List<AtaYearDto>> GetAtasCountByYear(List<int> years)
        {
            var atas = await _db.Atas.ToListAsync();
            var list = new List<AtaYearDto>();
            int count = 0;

            foreach (var year in years)
            {
                foreach (var ata in atas.Where(a => a.AnoAta.Equals(year)))
                {
                    count++;
                }
                list.Add(new AtaYearDto { Year = year, Count = count });
                count = 0;
            }
            return list;
        }

        public async Task<List<AtaMonthDto>> GetAtasCountByMonth()
        {
            var currentDate = DateTime.Now.Year;
            var atas = await _db.Atas.Where(a => a.DataCadastro.Year.Equals(currentDate)).ToListAsync();
            var list = new List<AtaMonthDto>();
            int count = 0;   

            for (int month = 1; month <= 12; month++)
            {
                var date = new DateTime(currentDate, month, 1);
                foreach (var ata in atas.Where(a => a.DataCadastro.Month.Equals(month)))
                {
                    count++;
                }
                list.Add(new AtaMonthDto { Month = date.ToString("MMM"), Count = count });
                count = 0;
            }
            return list;
        }

        public async Task<Ata> GetAtaPublish(int year, int code, bool publish)
        {
            return await _db.Atas
                .AsNoTracking()
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                    .ThenInclude(i => i.DetentoraItem)
                    .ThenInclude(d => d.Detentora)
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                    .ThenInclude(i => i.ParticipantesItens)
                    .ThenInclude(pt => pt.UnidadeAdministrativa)
                .Include(a => a.Itens.OrderBy(i => i.NumeroItem))
                    .ThenInclude(i => i.ParticipantesItens)
                    .ThenInclude(pt => pt.ProgramacoesConsumoParticipantes)
                .Where(a => a.AnoAta.Equals(year) && a.CodigoAta.Equals(code) && a.Publicada.Equals(publish))
                .FirstOrDefaultAsync();
        }

        public async Task<Ata> GetAtaByYearAndCodeAndPublish(int year, int code, bool publish)
        {
            return await _db.Atas
                .AsNoTracking()
                .Where(a => a.AnoAta.Equals(year) && a.CodigoAta.Equals(code) && a.Publicada.Equals(publish))
                .FirstOrDefaultAsync();
        }

        public async Task<int> CountAtasExpiredAll()
        {
            return await _db.Atas
               .AsNoTracking()
               .Where(a => a.DataVencimentoAta < DateTime.Now)
               .CountAsync();
        }
    }
}
