using Microsoft.AspNetCore.Mvc;
using ProdutoCrud.Dados.Model;
using ProdutoCrud.Dados.Models;
using ProdutoCrud.Services.Services.ProdutoService;
using System;
using System.Threading.Tasks;

namespace ProdutoCrud.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController: ControllerBase
    {

        [HttpPost()]
        public async Task<IActionResult> CriarProduto([FromServices] IProdutoService produtoService, [FromBody] CriarProdutoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Alguma das informações de produto estão inválidas");
                }

                var resultado = await produtoService.CriarProduto(model);
                return Ok(resultado);
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível criar o produto.");
            }
        }
        
        [HttpGet()]
        public async Task<IActionResult> ObterTodosProdutos([FromServices] IProdutoService produtoService, [FromQuery] ObterTodosParametrosQuery parametrosQuery)
        {
            try
            {
                var produtos = await produtoService.ObterTodosProdutos(parametrosQuery);
                return Ok(produtos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest($"Não foi possível buscar todos os produtos");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProdutoPorId([FromServices] IProdutoService produtoService, [FromRoute] int id)
        {
            try
            {
                var produto = await produtoService.ObterProdutoPorId(id);
                return Ok(produto);
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível buscar o produto com id: {id}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProdutoPorId([FromServices] IProdutoService produtoService, [FromRoute] int id, [FromBody] UpdateProdutoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Alguma das informações de produto estão inválidas");
                }

                await produtoService.AtualizarProduto(id, model);
                return Ok($"Produto com id: {id} atualizado com sucesso");
            }
            catch(Exception)
            {
                return BadRequest($"Não foi possível atualizar o produto com id: {id}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProdutoPorId([FromServices] IProdutoService produtoService, [FromRoute] int id)
        {
            try
            {
                await produtoService.DeletarProduto(id);
                return Ok($"Produto com id: {id} deletado com sucesso");
            }
            catch (Exception)
            {
                return BadRequest($"Não foi possível atualizar o produto com id: {id}");
            }
        }
    }
}
