using Microsoft.EntityFrameworkCore;
using ProdutoCrud.Dados.Entidades;
using ProdutoCrud.Dados.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoCrud.Dados.Repositories.ProdutoRepository
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<List<Produto>> ObterPorNomes(List<string> nomes)
        {
            return _dbSet.Where(x => nomes.Contains(x.Nome)).ToListAsync();
        }
    }
}
