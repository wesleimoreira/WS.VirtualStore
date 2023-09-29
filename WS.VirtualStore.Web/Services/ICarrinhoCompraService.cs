using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Web.Services
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDto>> GetItens(int usuarioId);
        Task<CarrinhoItemDto> DeletaItem(int carrinhoItemId);
        Task<CarrinhoItemDto> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItemDto> AtualizarQuantidade(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);

        event Action<int> OnCarrinhoCompraChanged;
        void ResiseEventOnCarrinhoCompraChanged(int totalQuantidade);
    }
}
