using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Persistencia
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public Task Adicionar(TEntity endity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TEntity endity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> BuscarPorChavesPrimariaComposta(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Task Deletar(TEntity endity)
        {
            throw new NotImplementedException();
        }
    }
}
