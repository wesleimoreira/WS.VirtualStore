using System.Net.Http.Json;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProdutoService> _logger;

        public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }     

        public async Task<ProdutoDto> GetItem(int produtoId)
        {
            try
            {
                var produtoDto = await _httpClient.GetFromJsonAsync<ProdutoDto>($"api/produtos/{produtoId}");

                if (produtoDto == null) return new ProdutoDto();

                return produtoDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetItens()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produtos");

                if (produtosDto == null) return Enumerable.Empty<ProdutoDto>();

                return produtosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }


        public async Task<IEnumerable<CategoriaDto>> GetCategorias()
        {
            try
            {
                var categorias = await _httpClient.GetFromJsonAsync<IEnumerable<CategoriaDto>>("api/Produtos/GetCategorias");

                if (categorias == null) return Enumerable.Empty<CategoriaDto>();

                return categorias;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var categorias = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>($"api/Produtos/GetItensPorCategoria/{categoriaId}");

                if (categorias == null) return Enumerable.Empty<ProdutoDto>();

                return categorias;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }
    }
}
