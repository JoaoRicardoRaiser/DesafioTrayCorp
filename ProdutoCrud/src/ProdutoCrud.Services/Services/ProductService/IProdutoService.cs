using ProdutoCrud.Dados.Model;
using ProdutoCrud.Dados.Entidades;
using ProdutoCrud.Dados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoCrud.Services.Services.ProdutoService
{
    public interface IProdutoService
    {
        public Task<Produto> CriarProduto(CriarProdutoModel model);
        public Task<List<Produto>> ObterTodosProdutos();
        public Task<List<Produto>> ObterTodosProdutos(ObterTodosParametrosQuery parametrosQuery);
        public Task<Produto> ObterProdutoPorId(int id);
        public Task AtualizarProduto(int id, UpdateProdutoModel dto);
        public Task DeletarProduto(int id);
    }
}
