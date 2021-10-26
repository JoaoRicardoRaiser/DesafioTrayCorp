using Microsoft.EntityFrameworkCore;
using ProdutoCrud.Dados.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoCrud.Dados.Repositories.GenericRepository
{
    public class GenericRepository<T>: IGenericRepository<T> where T: EntidadeBase
    {
        protected DbSet<T> _dbSet { get; private set; }
        
        public GenericRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public Task<List<T>> ObterTodosAsync()
        {
            return _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

    }
}
