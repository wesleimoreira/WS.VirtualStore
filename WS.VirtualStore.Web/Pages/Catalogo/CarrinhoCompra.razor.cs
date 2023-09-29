using Microsoft.JSInterop;
using WS.VirtualStore.Models.Dtos;
using WS.VirtualStore.Web.Services;
using Microsoft.AspNetCore.Components;

namespace WS.VirtualStore.Web.Pages.Catalogo
{
    public class CarrinhoComprabase : ComponentBase
    {
        [Inject] public required IJSRuntime JSRuntime { get; set; }
        [Inject] public required ICarrinhoCompraService CarrinhoCompraService { get; set; }
 
        protected int QuantidadeTotal { get; set; }
        protected string PrecoTotal {  get; set; } = default!;
        protected string MensagemErro { get; set; } = default!;
        protected List<CarrinhoItemDto> CarrinhoCompraItens { get; set; } = default!;


        protected override async Task OnInitializedAsync()
        {
            try
            {
                CarrinhoCompraItens = await CarrinhoCompraService.GetItens(UsuarioLogado.UsuarioId);

                CalcularResultadoCarrinhoTotal();
            }
            catch (Exception ex)
            {
                MensagemErro = ex.Message;
            }
        }

        protected async Task DeletaCarrinhoItem_Click(int carrinhoItemId)
        {
            // exclui do banco de dados
            var carrinhoCompraItem = await CarrinhoCompraService.DeletaItem(carrinhoItemId);
            // exclui da memoria 
            if (carrinhoCompraItem != null)           
                CarrinhoCompraItens.Remove(CarrinhoCompraItens.First(c => c.CarrinhoItemId == carrinhoItemId));


            CalcularResultadoCarrinhoTotal();
        }

        protected async Task AtualizarQuantidade_Input(int carrinhoItemId)
        {
            await JSRuntime.InvokeVoidAsync("TornarBotaoAtualizarQuantidadeVisivel", carrinhoItemId, true);            
        }

        protected async Task AtualizarCarrinhoItemQuantidade_Click(int carrinhoItemId, int carrinhoItemQuantidade)
        {
            try
            {
                if(carrinhoItemQuantidade > 0)
                {
                    var atualizarItemDto = new CarrinhoItemAtualizaQuantidadeDto
                    {
                        CarrinhoItemId = carrinhoItemId,
                        Quantidade = carrinhoItemQuantidade
                    };

                    var retornaItemAtualizadoDto = await CarrinhoCompraService.AtualizarQuantidade(atualizarItemDto);

                    AtualizarPrecoTotalItem(retornaItemAtualizadoDto);

                    await JSRuntime.InvokeVoidAsync("TornarBotaoAtualizarQuantidadeVisivel", carrinhoItemId, false);
                }
                else
                {
                    var carrinhoItem = CarrinhoCompraItens.Find(x => x.CarrinhoItemId == carrinhoItemId);
                    
                    if(carrinhoItem is not null)
                    {
                        carrinhoItem.CarrinhoItemQuantidade = 1;
                        carrinhoItem.PrecoTotal = carrinhoItem.ProdutoPreco;
                    }
                }
            }
            catch (Exception ex)
            {
                MensagemErro = ex.Message;
            }           
        }


        // metodos internos
        private void CalcularResultadoCarrinhoTotal()
        {
            PrecoTotal = CarrinhoCompraItens.Sum(x => x.PrecoTotal).ToString("c");

            QuantidadeTotal = CarrinhoCompraItens.Sum(x => x.CarrinhoItemQuantidade);

            CarrinhoCompraService.ResiseEventOnCarrinhoCompraChanged(QuantidadeTotal);
        }

        private void AtualizarPrecoTotalItem(CarrinhoItemDto carrinhoItemDto)
        {
            var carrinhoItem = CarrinhoCompraItens.Find(x => x.CarrinhoItemId == carrinhoItemDto.CarrinhoItemId);

            if (carrinhoItem != null)
                carrinhoItem.PrecoTotal = carrinhoItem.ProdutoPreco * carrinhoItem.CarrinhoItemQuantidade;

            CalcularResultadoCarrinhoTotal();
        }
    }
}
