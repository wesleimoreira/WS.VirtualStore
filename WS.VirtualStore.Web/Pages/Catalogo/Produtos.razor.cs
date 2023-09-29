using Microsoft.AspNetCore.Components;
using WS.VirtualStore.Models.Dtos;
using WS.VirtualStore.Web.Services;

namespace WS.VirtualStore.Web.Pages.Catalogo
{
    public class ProdutosBase : ComponentBase
    {
        [Inject] private IProdutoService ProdutoService { get; set; } = default!;
        [Inject] private ICarrinhoCompraService CarrinhoCompraService { get; set; } = default!;

        public IEnumerable<ProdutoDto> Produtos { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {           

            Produtos = await ProdutoService.GetItens();

            var carrinhoCompraItens = await CarrinhoCompraService.GetItens(UsuarioLogado.UsuarioId);

            if (carrinhoCompraItens != null)
                CarrinhoCompraService.ResiseEventOnCarrinhoCompraChanged(carrinhoCompraItens.Sum(x => x.CarrinhoItemQuantidade));
                
        }
    }
}
