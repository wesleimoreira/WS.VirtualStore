using Microsoft.AspNetCore.Mvc;
using WS.VirtualStore.Models.Dtos;
using WS.VirtualStore.Api.Mappings;
using WS.VirtualStore.Api.Repositories;

namespace WS.VirtualStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<CarrinhoCompraController> _logger;
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoCompraRepository, IProdutoRepository produtoRepository, ILogger<CarrinhoCompraController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _webHostEnvironment = webHostEnvironment;
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
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");

                if (_webHostEnvironment.IsDevelopment())
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);

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
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");

                if (_webHostEnvironment.IsDevelopment())
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);

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

                return StatusCode(StatusCodes.Status201Created, novoCarrinhoItemDto);     
            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");

                if (_webHostEnvironment.IsDevelopment())
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }

        [HttpDelete("{carrinhoItemId:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> DeleteItemAsync(int carrinhoItemId)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.DeletarItem(carrinhoItemId);

                if (carrinhoItem == null) return StatusCode(StatusCodes.Status400BadRequest, "Não foi possivel deletetar o produto do carrinho.");

                var produto = await _produtoRepository.GetItem(carrinhoItem.ProdutoId);

                if (produto == null) return StatusCode(StatusCodes.Status404NotFound, "Erro enesperado o produto não foi encontrado.");

                return StatusCode(StatusCodes.Status200OK, carrinhoItem.ConverterCarrinhoItemParaDto(produto));
            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");

                if (_webHostEnvironment.IsDevelopment())
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }

        [HttpPatch("{carrinhoItemId:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> UpdateItemAsync(int carrinhoItemId, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.AtualizarQuantidade(carrinhoItemId, carrinhoItemAtualizaQuantidadeDto);

                if (carrinhoItem == null) return StatusCode(StatusCodes.Status400BadRequest, "Não foi possivel atualizar a quantidade.");

                var produto = await _produtoRepository.GetItem(carrinhoItem.ProdutoId);

                if (produto == null) return StatusCode(StatusCodes.Status404NotFound, "O produto não foi encontrado");

                return StatusCode(StatusCodes.Status200OK, carrinhoItem.ConverterCarrinhoItemParaDto(produto));
            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao tentar acessar o banco de dados.");

                if (_webHostEnvironment.IsDevelopment())
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar acessar o banco de dados.");
            }
        }

    }
}
