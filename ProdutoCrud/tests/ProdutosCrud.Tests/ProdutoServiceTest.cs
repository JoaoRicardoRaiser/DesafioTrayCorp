using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ProdutoCrud.Dados;
using ProdutoCrud.Dados.Entidades;
using ProdutoCrud.Dados.Model;
using ProdutoCrud.Dados.Models;
using ProdutoCrud.Dados.Repositories.ProdutoRepository;
using ProdutoCrud.Services.Services.ProdutoService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutosCrud.Tests
{
    [TestClass]
    public class ProdutoServiceTest
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IProdutoService _produtoService;

        public ProdutoServiceTest()
        {
            _produtoRepository = Substitute.For<IProdutoRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _produtoService = new ProdutoService(_produtoRepository, _unitOfWork);
        }

        [TestMethod]
        public async Task DeveCriarProduto()
        {
            var model = new CriarProdutoModel { Nome = "Geladeira", Estoque = 10, Valor = 2999.99M };
            var resultado = await _produtoService.CriarProduto(model);
            
            await _produtoRepository
                .Received(1)
                .Create(Arg.Is<Produto>(
                    p => p.Nome == "Geladeira"
                    && p.Valor == 2999.99M
                    && p.Estoque == 10
                ));

            await _unitOfWork
                .Received(1)
                .CommitAsync();

            resultado.Nome.Should().Be("Geladeira");
            resultado.Estoque.Should().Be(10);
            resultado.Valor.Should().Be(2999.99M);
        }
        
        [TestMethod]
        public async Task DeveObterTodosProdutos()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Cafeteira", 5, 299.99M)
            };

            _produtoRepository
                .ObterTodosAsync()
                .Returns(produtos);

            var resultado = await _produtoService.ObterTodosProdutos();
            
            await _produtoRepository
                .Received(1)
                .ObterTodosAsync();

            resultado[0].Nome.Should().Be("Geladeira");
            resultado[0].Estoque.Should().Be(10);
            resultado[0].Valor.Should().Be(2999.99M);
            
            resultado[1].Nome.Should().Be("Cafeteira");
            resultado[1].Estoque.Should().Be(5);
            resultado[1].Valor.Should().Be(299.99M);
        }

        [TestMethod]
        public async Task DeveObterTodosProdutosComParametrosQueryPorValorOrderAsc()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Cafeteira", 5, 299.99M)
            };

            _produtoRepository
                .ObterTodosAsync()
                .Returns(produtos);

            var parametrosQuery = new ObterTodosParametrosQuery { CampoOrdenacao = "valor", OrdemAsc = true };
            var resultado = await _produtoService.ObterTodosProdutos(parametrosQuery);

            await _produtoRepository
                .Received(1)
                .ObterTodosAsync();

            resultado[0].Nome.Should().Be("Cafeteira");
            resultado[0].Estoque.Should().Be(5);
            resultado[0].Valor.Should().Be(299.99M);
            
            resultado[1].Nome.Should().Be("Geladeira");
            resultado[1].Estoque.Should().Be(10);
            resultado[1].Valor.Should().Be(2999.99M);
        }
        
        [TestMethod]
        public async Task DeveObterTodosProdutosComParametrosQueryPorValorOrderDesc()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Cafeteira", 5, 299.99M)
            };

            _produtoRepository
                .ObterTodosAsync()
                .Returns(produtos);

            var parametrosQuery = new ObterTodosParametrosQuery { CampoOrdenacao = "valor"};
            var resultado = await _produtoService.ObterTodosProdutos(parametrosQuery);

            await _produtoRepository
                .Received(1)
                .ObterTodosAsync();

            resultado[0].Nome.Should().Be("Geladeira");
            resultado[0].Estoque.Should().Be(10);
            resultado[0].Valor.Should().Be(2999.99M);
            
            resultado[1].Nome.Should().Be("Cafeteira");
            resultado[1].Estoque.Should().Be(5);
            resultado[1].Valor.Should().Be(299.99M);
        }
        
        [TestMethod]
        public async Task DeveObterTodosProdutosComParametrosQueryPorNomeOrderAsc()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Cafeteira", 5, 299.99M)
            };

            _produtoRepository
                .ObterTodosAsync()
                .Returns(produtos);

            var parametrosQuery = new ObterTodosParametrosQuery { CampoOrdenacao = "nome", OrdemAsc=true};
            var resultado = await _produtoService.ObterTodosProdutos(parametrosQuery);

            await _produtoRepository
                .Received(1)
                .ObterTodosAsync();
            
            resultado[0].Nome.Should().Be("Cafeteira");
            resultado[0].Estoque.Should().Be(5);
            resultado[0].Valor.Should().Be(299.99M);
            
            resultado[1].Nome.Should().Be("Geladeira");
            resultado[1].Estoque.Should().Be(10);
            resultado[1].Valor.Should().Be(2999.99M);
        }
        
        [TestMethod]
        public async Task DeveObterTodosProdutosComParametrosQueryPorNomeOrderDesc()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Cafeteira", 5, 299.99M)
            };

            _produtoRepository
                .ObterTodosAsync()
                .Returns(produtos);

            var parametrosQuery = new ObterTodosParametrosQuery { CampoOrdenacao = "nome"};
            var resultado = await _produtoService.ObterTodosProdutos(parametrosQuery);

            await _produtoRepository
                .Received(1)
                .ObterTodosAsync();
            
            resultado[0].Nome.Should().Be("Geladeira");
            resultado[0].Estoque.Should().Be(10);
            resultado[0].Valor.Should().Be(2999.99M);
            
            resultado[1].Nome.Should().Be("Cafeteira");
            resultado[1].Estoque.Should().Be(5);
            resultado[1].Valor.Should().Be(299.99M);
        }
        
        [TestMethod]
        public async Task DeveObterTodosProdutosComParametrosQueryPorEstoqueOrderAsc()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Cafeteira", 5, 299.99M)
            };

            _produtoRepository
                .ObterTodosAsync()
                .Returns(produtos);

            var parametrosQuery = new ObterTodosParametrosQuery { CampoOrdenacao = "estoque", OrdemAsc = true};
            var resultado = await _produtoService.ObterTodosProdutos(parametrosQuery);

            await _produtoRepository
                .Received(1)
                .ObterTodosAsync();
            
            resultado[0].Nome.Should().Be("Cafeteira");
            resultado[0].Estoque.Should().Be(5);
            resultado[0].Valor.Should().Be(299.99M);
            
            resultado[1].Nome.Should().Be("Geladeira");
            resultado[1].Estoque.Should().Be(10);
            resultado[1].Valor.Should().Be(2999.99M);
        }
        
        [TestMethod]
        public async Task DeveObterTodosProdutosComParametrosQueryPorEstoqueOrderDesc()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Cafeteira", 5, 299.99M)
            };

            _produtoRepository
                .ObterTodosAsync()
                .Returns(produtos);

            var parametrosQuery = new ObterTodosParametrosQuery { CampoOrdenacao = "estoque"};
            var resultado = await _produtoService.ObterTodosProdutos(parametrosQuery);

            await _produtoRepository
                .Received(1)
                .ObterTodosAsync();

            resultado[0].Nome.Should().Be("Geladeira");
            resultado[0].Estoque.Should().Be(10);
            resultado[0].Valor.Should().Be(2999.99M);

            resultado[1].Nome.Should().Be("Cafeteira");
            resultado[1].Estoque.Should().Be(5);
            resultado[1].Valor.Should().Be(299.99M);
        }
        
        [TestMethod]
        public async Task DeveObterTodosProdutosComParametrosQueryPorNomes()
        {
            var produtos = new List<Produto>
            {
                new Produto("Geladeira", 10, 2999.99M),
                new Produto("Celular", 29, 1299.99M)
            };

            _produtoRepository
                .ObterPorNomes(Arg.Is<List<string>>(
                    p => p[0] == "Celular"
                    && p[1] == "Geladeira"
                ))
                .Returns(produtos);

            var nomes = new List<string>
            {
                "Celular",
                "Geladeira"
            };
            var parametrosQuery = new ObterTodosParametrosQuery { Nomes = nomes };
            var resultado = await _produtoService.ObterTodosProdutos(parametrosQuery);

            await _produtoRepository
                .Received(1)
                .ObterPorNomes(Arg.Is<List<string>>(
                    p => p[0] == "Celular"
                    && p[1] == "Geladeira"
                ));

            resultado[0].Nome.Should().Be("Geladeira");
            resultado[0].Estoque.Should().Be(10);
            resultado[0].Valor.Should().Be(2999.99M);

            resultado[1].Nome.Should().Be("Celular");
            resultado[1].Estoque.Should().Be(29);
            resultado[1].Valor.Should().Be(1299.99M);
        }
    }
}
