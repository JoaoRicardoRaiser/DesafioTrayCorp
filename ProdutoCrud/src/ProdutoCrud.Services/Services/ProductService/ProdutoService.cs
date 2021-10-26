using ProdutoCrud.Dados;
using ProdutoCrud.Dados.Model;
using ProdutoCrud.Dados.Entidades;
using ProdutoCrud.Dados.Models;
using ProdutoCrud.Dados.Repositories.ProdutoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutoCrud.Utils;

namespace ProdutoCrud.Services.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Produto> CriarProduto(CriarProdutoModel model)
        {
            var produto = new Produto(model.Nome, model.Estoque, model.Valor);
            await _produtoRepository.Create(produto);

            await _unitOfWork.CommitAsync();
            return produto;
        }

        public async Task<List<Produto>> ObterTodosProdutos()
        {
            return await _produtoRepository.ObterTodosAsync();
        }

        public async Task<List<Produto>> ObterTodosProdutos(ObterTodosParametrosQuery parametrosQuery)
        {
            var campoOrdenacao = parametrosQuery.CampoOrdenacao;
            List<Produto> produtos;
            
            if (!parametrosQuery.TemNomes())
            {
                produtos = await _produtoRepository.ObterTodosAsync();
                return OrdenarProdutosPorCampo(produtos, campoOrdenacao, parametrosQuery.OrdemAsc);
            }

            produtos = await _produtoRepository.ObterPorNomes(parametrosQuery.Nomes);
            return OrdenarProdutosPorCampo(produtos, campoOrdenacao, parametrosQuery.OrdemAsc);
        }


        public async Task<Produto> ObterProdutoPorId(int id)
        {
            return await _produtoRepository.ObterPorIdAsync(id);
        }

        public async Task AtualizarProduto(int id, UpdateProdutoModel dto)
        {
            var produtoSalvo = await _produtoRepository.ObterPorIdAsync(id);
            if(produtoSalvo == null)
            {
                var exception = new Exception($"Não foi possível encontrar o produto com id: {id} para atualizar.");
                throw exception;
            }
            produtoSalvo.Update(dto.Estoque, dto.Valor);
            _produtoRepository.Update(produtoSalvo);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeletarProduto(int id)
        {
            var produtoSalvo = await _produtoRepository.ObterPorIdAsync(id);
            if (produtoSalvo == null)
            {
                var exception = new Exception($"Não foi possível encontrar o produto com id: {id} para atualizar.");
                throw exception;
            }
            _produtoRepository.Delete(produtoSalvo);
            await _unitOfWork.CommitAsync();
        }
        
        private static List<Produto> OrdenarProdutosPorCampo(List<Produto> produtos, string campo, bool OrdemAsc)
        {
            var campoOrderBy = typeof(Produto).GetProperty(campo?.PrimeiraMaiuscula() ?? "Nome");
            
            if (OrdemAsc)
            {
                return produtos?.OrderBy(p => campoOrderBy?.GetValue(p)).ToList();
            }
            return produtos?.OrderByDescending(p => campoOrderBy?.GetValue(p)).ToList();
        }
    }
}
