using Microsoft.AspNetCore.Components;
using WS.VirtualStore.Models.Dtos;
using WS.VirtualStore.Web.Services;

namespace WS.VirtualStore.Web.Pages.Catalogo
{
    public class ProdutosBase : ComponentBase
    {
        [Inject]
        private IProdutoService ProdutoService { get; set; } = default!;      

        public IEnumerable<ProdutoDto> Produtos { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {           

            Produtos = await ProdutoService.GetItens();
        }
    }
}
