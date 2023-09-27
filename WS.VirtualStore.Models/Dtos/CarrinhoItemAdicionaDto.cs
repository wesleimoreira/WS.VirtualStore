namespace WS.VirtualStore.Models.Dtos
{
    public class CarrinhoItemAdicionaDto
    {
        public required int CarrinhoId { get; set; }
        public required int ProdutoId { get; set; }
        public required int Quantidade { get; set; }
    }
}
