using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Web.Services
{
    public interface IGerenciaCarrinhoItensLocalStorageService
    {
        Task<List<CarrinhoItemDto>> GetCollection();
        Task SaveCollection(List<CarrinhoItemDto> carrinhoItensDto);
        Task RemoveCollection();
    }
}
