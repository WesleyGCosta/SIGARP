using Dominio.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia
{
    public abstract class BaseRepository<TEndity> : IBaseRepository<TEndity> where TEndity : class
    {
        public Task Adicionar(TEndity endity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TEndity endity)
        {
            throw new NotImplementedException();
        }

        public Task<TEndity> BuscarPorChavesPrimariaComposta(int chaveUm, int chaveDois)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEndity>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task Deletar(TEndity endity)
        {
            throw new NotImplementedException();
        }
    }
}
