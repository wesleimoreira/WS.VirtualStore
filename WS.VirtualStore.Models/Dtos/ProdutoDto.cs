namespace WS.VirtualStore.Models.Dtos
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string? ProdutoNome { get; set; }
        public string? ProdutoDescricao { get; set; }
        public string? ProdutoImagem { get; set; }
        public decimal ProdutoPreco { get; set; }
        public int ProdutoQuantidade { get; set; }
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; } 
    }
}
