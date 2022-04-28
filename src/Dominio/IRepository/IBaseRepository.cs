using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.IRepository
{
    public interface IBaseRepository<TEndity> where TEndity : class
    {
        Task Adicionar(TEndity endity);
        Task Atualizar(TEndity endity);
        Task Deletar(TEndity endity);
        Task<TEndity> BuscarPorChavesPrimariaComposta(int chaveUm, int chaveDois);
        Task<IEnumerable<TEndity>> BuscarTodos();
    }
}
