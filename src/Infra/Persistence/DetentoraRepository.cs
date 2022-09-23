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
    public class DetentoraRepository : BaseRepository<Detentora>, IDetentoraRepository
    {
        public DetentoraRepository(DataContext db) : base(db)
        {
        }

        public async Task<Detentora> GetByCnpj(string cnpj)
        {
            return await _db.Detentoras
                .Where(d => d.Cnpj.Equals(cnpj))
                .FirstOrDefaultAsync();
        }

        public async Task<Detentora> GetIdInclude(Guid id)
        {
            return await _db.Detentoras
                .Include(d => d.Enderecos)
                .Where(d => d.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Detentora>> GetListDetentoraItemByAta(int yearAta, int codeAta)
        {
            return await _db.Detentoras
                .Where(d => d.DetentorasItens.Any(di => di.Item.AnoAta.Equals(yearAta) && di.Item.CodigoAta.Equals(codeAta)))
                .ToListAsync();
        }
    }
}
