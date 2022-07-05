using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Adicionar(TEntity endity);
        Task Atualizar(TEntity endity);
        Task Deletar(TEntity endity);
        Task<TEntity> BuscarPorChavesPrimariaComposta(Guid id);
        Task<IEnumerable<TEntity>> BuscarTodos();
    }
}
