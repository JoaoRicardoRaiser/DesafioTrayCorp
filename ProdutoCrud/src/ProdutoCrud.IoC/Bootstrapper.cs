using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProdutoCrud.Dados;
using ProdutoCrud.Dados.Repositories.ProdutoRepository;
using ProdutoCrud.Database;
using ProdutoCrud.Services.Services.ProdutoService;

namespace ProdutoCrud.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegistrarServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DbContext, ProdutoCrudDbContext>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IProdutoRepository, ProdutoRepository>();
            
            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            
            return serviceCollection;
        }
    }
}
