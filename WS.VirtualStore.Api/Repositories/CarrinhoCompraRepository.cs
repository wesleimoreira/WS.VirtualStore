using Microsoft.EntityFrameworkCore;
using WS.VirtualStore.Api.Context;
using WS.VirtualStore.Api.Entities;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Api.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarrinhoCompraRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CarrinhoItem> GetItem(int carrinhoItemId)
        {
            return await (from carrinho in _appDbContext.Carrinhos
                          join carrinhoItem in _appDbContext.CarrinhoItems
                          on carrinho.CarrinhoId equals carrinhoItem.CarrinhoItemId
                          where carrinhoItem.CarrinhoItemId == carrinhoItemId
                          select new CarrinhoItem
                          {
                              CarrinhoItemId = carrinhoItem.CarrinhoItemId,
                              ProdutoId = carrinhoItem.ProdutoId,
                              CarrinhoItemQuantidade = carrinhoItem.CarrinhoItemQuantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).SingleAsync();
        }

        public async Task<IEnumerable<CarrinhoItem>> GetItens(int usuarioId)
        {
            return await (from carrinho in _appDbContext.Carrinhos
                          join carrinhoItem in _appDbContext.CarrinhoItems
                          on carrinho.CarrinhoId equals carrinhoItem.CarrinhoId
                          where carrinho.UsuarioId == usuarioId
                          select new CarrinhoItem
                          {
                              CarrinhoItemId = carrinhoItem.CarrinhoItemId,
                              ProdutoId = carrinhoItem.ProdutoId,
                              CarrinhoItemQuantidade = carrinhoItem.CarrinhoItemQuantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).ToListAsync();

        }

        public async Task<CarrinhoItem> DeletarItem(int carrinhoItemId)
        {
            var item = await _appDbContext.CarrinhoItems.FindAsync(carrinhoItemId);

            if (item == null) return default!;

            _appDbContext.CarrinhoItems.Remove(item);

            await _appDbContext.SaveChangesAsync();

            return item;
        }

        public async Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            var carrinhoItem = await CarrinhoItemJaExiste(carrinhoItemAdicionaDto.CarrinhoId, carrinhoItemAdicionaDto.ProdutoId);

            if (carrinhoItem is null)
            {
                // verifica se o produto existe e criar um novo item no carrinho
                var item = await (from produto in _appDbContext.Produtos
                                  where produto.ProdutoId == carrinhoItemAdicionaDto.ProdutoId
                                  select new CarrinhoItem
                                  {
                                      CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
                                      ProdutoId = carrinhoItemAdicionaDto.ProdutoId,
                                      CarrinhoItemQuantidade = carrinhoItemAdicionaDto.CarrinhoItemQuantidade,

                                  }).SingleAsync();

                // se o iem existe então incluir o item no carrinho
                if (item is not null)
                {
                    var resultado = await _appDbContext.CarrinhoItems.AddAsync(item);
                    await _appDbContext.SaveChangesAsync();
                    return resultado.Entity;
                }
            }

            if (carrinhoItem is not null)
            {
                carrinhoItem.CarrinhoItemQuantidade += 1;
                await _appDbContext.SaveChangesAsync();
                return carrinhoItem;
            }

            return default!;
        }

        public async Task<CarrinhoItem> AtualizarQuantidade(int carrinhoItemId, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            var carrinhoItem = await _appDbContext.CarrinhoItems.FindAsync(carrinhoItemId);

            if (carrinhoItem is not null)
            {
                carrinhoItem.CarrinhoItemQuantidade = carrinhoItemAtualizaQuantidadeDto.Quantidade;

                await _appDbContext.SaveChangesAsync();

                return carrinhoItem;
            }

            return default!;
        }


        private async Task<CarrinhoItem?> CarrinhoItemJaExiste(int carrinhoId, int produtoId)
        {
            return await (from carrinhoItem in _appDbContext.CarrinhoItems
                          where carrinhoItem.CarrinhoId == carrinhoId && carrinhoItem.ProdutoId == produtoId
                          select carrinhoItem).FirstOrDefaultAsync();
        }
    }
}
