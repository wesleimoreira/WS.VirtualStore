using Microsoft.AspNetCore.Mvc;
using WS.VirtualStore.Api.Mappings;
using WS.VirtualStore.Api.Repositories;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();

                if (produtos == null) return StatusCode(StatusCodes.Status204NoContent, "Não foi encontrado produtos cadastrados.");

                return Ok(produtos.ConverterProdutosParaDto());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }


        [HttpGet("{produtoId:int}")]
        public async Task<ActionResult<ProdutoDto>> GetItem(int produtoId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItem(produtoId);

                if (produtos == null) return StatusCode(StatusCodes.Status404NotFound, $"O Produto com o ID: {produtoId} não foi localizado.");

                return Ok(produtos.ConverterProdutoParaDto());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }

        [HttpGet]
        [Route("GetItensPorCategoria/{categoriaId:int}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);

                if (produtos == null) return StatusCode(StatusCodes.Status404NotFound, $"O Produto com a categoria: {categoriaId} não foi localizado.");

                return Ok(produtos.ConverterProdutosParaDto());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }

    }
}
