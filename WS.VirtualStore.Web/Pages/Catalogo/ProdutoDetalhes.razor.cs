using Microsoft.AspNetCore.Components;
using WS.VirtualStore.Models.Dtos;
using WS.VirtualStore.Web.Services;

namespace WS.VirtualStore.Web.Pages.Catalogo
{
    public class ProdutoDetalhesBase : ComponentBase
    {
        [Inject] public required IProdutoService ProdutoService { get; set; }
        [Inject] public required NavigationManager NavigationManager { get; set; }
        [Inject] public required ICarrinhoCompraService CarrinhoCompraService { get; set; }
        [Inject] public required IGerenciaProdutosLocalStorageService GerenciaProdutosLocalStorageService { get; set; }
        [Inject] public required IGerenciaCarrinhoItensLocalStorageService GerenciaCarrinhoItensLocalStorageService { get; set; }

        [Parameter] public required int ProdutoId { get; set; }

        public required ProdutoDto Produto { get; set; }
        protected string MensagemErro { get; set; } = default!;
        protected List<CarrinhoItemDto> CarrinhoCompraItens { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                CarrinhoCompraItens = await GerenciaCarrinhoItensLocalStorageService.GetCollection();         

                var produtosDto = await GerenciaProdutosLocalStorageService.GetCollection();

                if (produtosDto != null)
                    Produto = produtosDto.First(p => p.ProdutoId == ProdutoId);              

            }
            catch (Exception ex)
            {
                MensagemErro = ex.Message;
            }
        }

        protected async Task AdicionarAoCarrinho_Click(int produtoId)
        {
            try
            {
                var carrinhoItemDto = await CarrinhoCompraService.AdicionarItem(new CarrinhoItemAdicionaDto
                {
                    ProdutoId = produtoId,
                    CarrinhoItemQuantidade = 1,
                    CarrinhoId = UsuarioLogado.CarrinhoId
                });

                NavigationManager.NavigateTo("/CarrinhoCompra");
            }
            catch (Exception ex)
            {
                MensagemErro = ex.Message;
            }
        }
    }
}
