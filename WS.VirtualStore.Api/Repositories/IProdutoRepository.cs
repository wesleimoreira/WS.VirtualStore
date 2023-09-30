using WS.VirtualStore.Api.Entities;

namespace WS.VirtualStore.Api.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> GetItem(int produtoId);
        Task<IEnumerable<Produto>> GetItens();
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<IEnumerable<Produto>> GetItensPorCategoria(int categoriaId);
    }
}
