using WS.VirtualStore.Api.Entities;
using WS.VirtualStore.Models.Dtos;

namespace WS.VirtualStore.Api.Mappings
{
    public static class MappingDtos
    {
        public static IEnumerable<CategoriaDto> ConverterCategoriasParaDto(this IEnumerable<Categoria> categorias)
        {
            return (from categoria in categorias
                    select new CategoriaDto
                    {
                        CategoriaId = categoria.CategoriaId,
                        CategoriaNome = categoria.CategoriaNome,
                        CategoriaIcone = categoria.CategoriaIcone
                    }).ToList();
        }

        public static IEnumerable<ProdutoDto> ConverterProdutosParaDto(this IEnumerable<Produto> produtos)
        {
            return (from produto in produtos
                    select new ProdutoDto
                    {
                        ProdutoId = produto.ProdutoId,
                        ProdutoNome = produto.ProdutoNome,
                        ProdutoDescricao = produto.ProdutoDescricao,
                        ProdutoImagem = produto.ProdutoImagem,
                        ProdutoPreco = produto.ProdutoPreco,
                        ProdutoQuantidade = produto.ProdutoQuantidade,
                        CategoriaId = produto.Categoria.CategoriaId,
                        CategoriaNome = produto.Categoria.CategoriaNome
                    }).ToList();
        }

        public static ProdutoDto ConverterProdutoParaDto(this Produto produto)
        {
            return new ProdutoDto
            {
                ProdutoId = produto.ProdutoId,
                ProdutoNome = produto.ProdutoNome,
                ProdutoDescricao = produto.ProdutoDescricao,
                ProdutoImagem = produto.ProdutoImagem,
                ProdutoPreco = produto.ProdutoPreco,
                ProdutoQuantidade = produto.ProdutoQuantidade,
                CategoriaId = produto.Categoria.CategoriaId,
                CategoriaNome = produto.Categoria.CategoriaNome
            };
        }

        public static IEnumerable<CarrinhoItemDto> ConverterCarrinhoItensParaDto(this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.ProdutoId equals produto.ProdutoId
                    select new CarrinhoItemDto
                    {
                        CarrinhoItemId = carrinhoItem.CarrinhoItemId,
                        ProdutoId = carrinhoItem.ProdutoId,
                        ProdutoNome = produto.ProdutoNome,
                        ProdutoDescricao = produto.ProdutoDescricao,
                        ProdutoImagem = produto.ProdutoImagem,
                        ProdutoPreco = produto.ProdutoPreco,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        CarrinhoItemQuantidade = carrinhoItem.CarrinhoItemQuantidade,
                        PrecoTotal = produto.ProdutoPreco * carrinhoItem.CarrinhoItemQuantidade
                    }).ToList();
        }

        public static CarrinhoItemDto ConverterCarrinhoItemParaDto(this CarrinhoItem carrinhoItem, Produto produto)
        {
            return new CarrinhoItemDto
            {
                CarrinhoItemId = carrinhoItem.CarrinhoItemId,
                ProdutoId = carrinhoItem.ProdutoId,
                ProdutoNome = produto.ProdutoNome,
                ProdutoDescricao = produto.ProdutoDescricao,
                ProdutoImagem = produto.ProdutoImagem,
                ProdutoPreco = produto.ProdutoPreco,
                CarrinhoId = carrinhoItem.CarrinhoId,
                CarrinhoItemQuantidade = carrinhoItem.CarrinhoItemQuantidade,
                PrecoTotal = produto.ProdutoPreco * carrinhoItem.CarrinhoItemQuantidade
            };
        }
    }
}
