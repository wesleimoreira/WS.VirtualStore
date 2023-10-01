using System.Net;
using System.Net.Http.Json;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProdutoService> _logger;

        public event Action<int> OnCarrinhoCompraChanged;

        public CarrinhoCompraService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<List<CarrinhoItemDto>> GetItens(int usuarioId)
        {
            try
            {
                var carrinhoItemDto = await _httpClient.GetFromJsonAsync<List<CarrinhoItemDto>>($"api/CarrinhoCompra/{usuarioId}/GetItens");

                if (carrinhoItemDto == null) return default!;

                return carrinhoItemDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }

        public async Task<CarrinhoItemDto> DeletaItem(int carrinhoItemId)
        {
            try
            {
                var carrinhoItem = await _httpClient.DeleteFromJsonAsync<CarrinhoItemDto>($"api/CarrinhoCompra/{carrinhoItemId}");

                if (carrinhoItem == null) return default!;

                return carrinhoItem;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }

        public async Task<CarrinhoItemDto> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var addCarrinhoItem = await _httpClient.PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/CarrinhoCompra", carrinhoItemAdicionaDto);

                if (addCarrinhoItem.StatusCode != HttpStatusCode.Created) return default!;

                var carrinhoItemDto = await addCarrinhoItem.Content.ReadFromJsonAsync<CarrinhoItemDto>();

                if (carrinhoItemDto == null) return default!;

                return carrinhoItemDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }

        public async Task<CarrinhoItemDto> AtualizarQuantidade(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var response = await _httpClient.PatchAsJsonAsync($"api/CarrinhoCompra/{carrinhoItemAtualizaQuantidadeDto.CarrinhoItemId}", carrinhoItemAtualizaQuantidadeDto);

                if (response.StatusCode != HttpStatusCode.OK) return default!;

                var carrinhoItem = await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();

                if (carrinhoItem == null) return default!;

                return carrinhoItem;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao tentar consulmir a api na rota : api/produtos");
                throw;
            }
        }

        public void ResiseEventOnCarrinhoCompraChanged(int totalQuantidade)
        {
            OnCarrinhoCompraChanged?.Invoke(totalQuantidade);
        }
    }
}
