using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Web.Services
{
    public interface IGerenciaProdutosLocalStorageService
    {
        Task<IEnumerable<ProdutoDto>> GetCollection();
        Task RemoveCollection();
    }

}
