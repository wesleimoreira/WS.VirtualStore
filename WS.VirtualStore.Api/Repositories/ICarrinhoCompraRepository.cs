using WS.VirtualStore.Api.Entities;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Api.Repositories
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> GetItem(int carrinhoItemId);
        Task<CarrinhoItem> DeletarItem(int carrinhoItemId);
        Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId);
        Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItem> AtualizarQuantidade(int carrinhoItemId, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);
    }
}
