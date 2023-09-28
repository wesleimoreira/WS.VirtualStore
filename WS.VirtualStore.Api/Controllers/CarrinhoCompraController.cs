using Microsoft.AspNetCore.Mvc;
using WS.VirtualStore.Api.Entities;
using WS.VirtualStore.Api.Mappings;
using WS.VirtualStore.Api.Repositories;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<CarrinhoCompraController> _logger;
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoCompraRepository, IProdutoRepository produtoRepository, ILogger<CarrinhoCompraController> logger)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }

        [HttpGet]
        [Route("{usuarioId}/GetItens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetItensAsync(int usuarioId)
        {
            try
            {
                var carrinhoItens = await _carrinhoCompraRepository.GetItens(usuarioId);

                if (carrinhoItens == null) return StatusCode(StatusCodes.Status204NoContent, "O carrinho está vazio para esse usuário.");

                var produtos = await _produtoRepository.GetItens();

                if (produtos == null) return StatusCode(StatusCodes.Status204NoContent, "Não foram encontrados produtos cadastrados.");              

                return StatusCode(StatusCodes.Status200OK, carrinhoItens.ConverterCarrinhoItensParaDto(produtos));
            }
            catch (Exception)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }

        [HttpGet]
        [Route("{carrinhoItemId:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> GetItemAsync(int carrinhoItemId)
        {
            try
            {
                var carrinhoItens = await _carrinhoCompraRepository.GetItem(carrinhoItemId);

                if (carrinhoItens == null) return StatusCode(StatusCodes.Status204NoContent, "O carrinho está vazio para esse usuário.");

                var produto = await _produtoRepository.GetItem(carrinhoItens.ProdutoId);

                if (produto == null) return StatusCode(StatusCodes.Status204NoContent, "Não foram encontrados produtos cadastrados.");

                return StatusCode(StatusCodes.Status200OK, carrinhoItens.ConverterCarrinhoItemParaDto(produto));

            }
            catch (Exception)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> PostItemAsync([FromBody] CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await _carrinhoCompraRepository.AdicionarItem(carrinhoItemAdicionaDto);

                if (novoCarrinhoItem == null) return StatusCode(StatusCodes.Status404NotFound, "Não foi possivel adicionar o produto no carrinho.");

                var produto = await _produtoRepository.GetItem(novoCarrinhoItem.ProdutoId);

                if (produto == null) return StatusCode(StatusCodes.Status404NotFound, "Não foram encontrados produtos cadastrados.");

                var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItemParaDto(produto);

                return CreatedAtAction(nameof(GetItemAsync), new { carrinhoItemId = novoCarrinhoItemDto.CarrinhoItemId}, novoCarrinhoItemDto);

            }
            catch (Exception)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }
    }
}
