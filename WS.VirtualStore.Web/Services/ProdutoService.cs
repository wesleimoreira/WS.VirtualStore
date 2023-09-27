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
    }
}
