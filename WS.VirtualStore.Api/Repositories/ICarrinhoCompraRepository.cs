using WS.VirtualStore.Api.Entities;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Api.Repositories
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> GetItem(int CarrinhoItemId);
        Task<CarrinhoItem> DeletarItem(int CarrinhoItemId);
        Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId);
        Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
        Task<CarrinhoItem> AtualizarQuantidade(int CarrinhoItemId, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);
    }
}
