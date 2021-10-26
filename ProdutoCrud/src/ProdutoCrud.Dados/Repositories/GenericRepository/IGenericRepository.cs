using ProdutoCrud.Dados.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoCrud.Dados.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : EntidadeBase
    {
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}