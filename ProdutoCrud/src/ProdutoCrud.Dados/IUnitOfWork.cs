using System.Threading.Tasks;

namespace ProdutoCrud.Dados
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task Rollback();
    }
}