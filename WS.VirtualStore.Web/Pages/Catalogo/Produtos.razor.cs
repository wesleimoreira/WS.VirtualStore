using Microsoft.AspNetCore.Components;
using WS.VirtualStore.Models.Dtos;
using WS.VirtualStore.Web.Services;

namespace WS.VirtualStore.Web.Pages.Catalogo
{
    public class ProdutosBase : ComponentBase
    {
        [Inject] private IProdutoService ProdutoService { get; set; } = default!;
        [Inject] private ICarrinhoCompraService CarrinhoCompraService { get; set; } = default!;
        [Inject] private IGerenciaProdutosLocalStorageService GerenciaProdutosLocalStorageService { get; set; } = default!;
        [Inject] private IGerenciaCarrinhoItensLocalStorageService GerenciaCarrinhoItensLocalStorageService { get; set; } = default!;

        public IEnumerable<ProdutoDto> Produtos { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await LimpaLocalStorage();

            Produtos = await GerenciaProdutosLocalStorageService.GetCollection();

            var carrinhoCompraItens = await GerenciaCarrinhoItensLocalStorageService.GetCollection();

            var totalQuantidade = carrinhoCompraItens.Sum(i => i.CarrinhoItemQuantidade);

            CarrinhoCompraService.ResiseEventOnCarrinhoCompraChanged(totalQuantidade);

        }

        private async Task LimpaLocalStorage()
        {
            await GerenciaProdutosLocalStorageService.RemoveCollection();
            await GerenciaCarrinhoItensLocalStorageService.RemoveCollection();
        }
    }
}
