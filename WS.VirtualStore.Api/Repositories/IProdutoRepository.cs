using WS.VirtualStore.Api.Entities;

namespace WS.VirtualStore.Api.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetItens();
        Task<Produto> GetItem(int produtoId);
        Task<IEnumerable<Produto>> GetItensPorCategoria(int categoriaId);
    }
}
