using Microsoft.AspNetCore.Components;
using WS.VirtualStore.Models.Dtos;
using WS.VirtualStore.Web.Services;

namespace WS.VirtualStore.Web.Pages.Catalogo
{
    public class ProdutoDetalhesBase : ComponentBase
    {
        [Inject]
        public required IProdutoService ProdutoService { get; set; }

        [Parameter]
        public required int ProdutoId { get; set; }

        public ProdutoDto Produto { get; set; } = default!;

        public string MensagemErro { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Produto = await ProdutoService.GetItem(ProdutoId);
            }
            catch (Exception ex)
            {
                MensagemErro = ex.Message;
            }
        }
    }
}
