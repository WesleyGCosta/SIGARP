using Dominio.Entidade;
using Dominio.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia
{
    public class AtaRepository : BaseRepository<Ata>, IAtaRepository
    {
    }
}
