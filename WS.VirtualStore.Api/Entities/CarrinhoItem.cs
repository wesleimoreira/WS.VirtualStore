namespace WS.VirtualStore.Api.Entities
{
    public class CarrinhoItem
    {
        public int CarrinhoItemId { get; set; }

        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }  
        public int CarrinhoItemQuantidade { get; set; }

        //EF
        public Carrinho? Carrinho { get; set; }
        public Produto? Produto { get; set; }
    }
}
