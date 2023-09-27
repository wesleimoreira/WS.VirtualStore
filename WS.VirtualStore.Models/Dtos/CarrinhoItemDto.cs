namespace WS.VirtualStore.Models.Dtos
{
    public class CarrinhoItemDto
    {
        public int CarrinhoItemId { get; set; } 
        public int ProdutoId { get; set; }
        public int CarrinhoId { get; set; }
        public int CarrinhoItemQuantidade { get; set; }

        public string? ProdutoNome { get; set; }
        public string? ProdutoDescricao { get; set; }
        public string? ProdutoImagem { get; set; }
        public decimal ProdutoPreco { get; set; }
        public decimal PrecoTotal { get; set; }
    }

}
