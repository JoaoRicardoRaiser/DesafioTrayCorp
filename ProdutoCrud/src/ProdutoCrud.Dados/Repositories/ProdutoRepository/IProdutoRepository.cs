using ProdutoCrud.Dados.Entidades;
using ProdutoCrud.Dados.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoCrud.Dados.Repositories.ProdutoRepository
{
    public interface IProdutoRepository: IGenericRepository<Produto>
    {
        Task<List<Produto>> ObterPorNomes(List<string> nomes);
    }
}
