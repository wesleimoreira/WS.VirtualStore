using Microsoft.EntityFrameworkCore;
using WS.VirtualStore.Api.Context;
using WS.VirtualStore.Api.Entities;

namespace WS.VirtualStore.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Produto> GetItem(int produtoId)
        {
            return await _appDbContext.Produtos.Include(pro => pro.Categoria).SingleAsync(pro => pro.ProdutoId == produtoId);
        }

        public async Task<IEnumerable<Produto>> GetItens()
        {
            return await _appDbContext.Produtos.Include(pro => pro.Categoria).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int categoriaId)
        {
            return await _appDbContext.Produtos.Include(pro => pro.Categoria).Where(pro => pro.CategoriaId == categoriaId).ToListAsync();
        }
    }
}
