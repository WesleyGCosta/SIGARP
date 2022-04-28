using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Criar(TEntity entity);
        Task Excluir(TEntity entity);
        Task Atualizar(TEntity entity);

        Task<TEntity> BuscarPorId(Guid id);
        Task<IEnumerable<TEntity>> ListarTodos();
    }
}
