using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Web.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> GetItem(int produtoId);
        Task<IEnumerable<ProdutoDto>> GetItens();
    }
}
