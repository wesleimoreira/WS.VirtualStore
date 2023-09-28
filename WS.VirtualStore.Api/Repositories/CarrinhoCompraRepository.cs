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

        public async Task<CarrinhoItem> GetItem(int CarrinhoItemId)
        {
            return await (from carrinho in _appDbContext.Carrinhos
                          join carrinhoItem in _appDbContext.CarrinhoItems
                          on carrinho.CarrinhoId equals carrinhoItem.CarrinhoItemId
                          where carrinhoItem.CarrinhoItemId == CarrinhoItemId
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
                          on carrinho.CarrinhoId equals carrinhoItem.CarrinhoItemId
                          where carrinho.UsuarioId == usuarioId
                          select new CarrinhoItem
                          {
                              CarrinhoItemId = carrinhoItem.CarrinhoItemId,
                              ProdutoId = carrinhoItem.ProdutoId,
                              CarrinhoItemQuantidade = carrinhoItem.CarrinhoItemQuantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).ToListAsync();

        }

        public Task<CarrinhoItem> DeletarItem(int CarrinhoItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoItem> AdicionarItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            if (await CarrinhoItemJaExiste(carrinhoItemAdicionaDto.CarrinhoId, carrinhoItemAdicionaDto.ProdutoId) == false)
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

            return default!;
        }

        public Task<CarrinhoItem> AtualizarQuantidade(int CarrinhoItemId, CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            throw new NotImplementedException();
        }


        private async Task<bool> CarrinhoItemJaExiste(int carrinhoId, int produtoId)
        {
            return await _appDbContext.CarrinhoItems.AnyAsync(ca => ca.CarrinhoId == carrinhoId && ca.ProdutoId == produtoId);
        }
    }
}
