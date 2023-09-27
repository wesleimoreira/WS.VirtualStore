using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WS.VirtualStore.Api.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [MaxLength(100)]
        public string ProdutoNome { get; set; } = string.Empty;
        [MaxLength(200)]
        public string ProdutoDescricao { get; set; } = string.Empty;
        [MaxLength(200)]
        public string ProdutoImagem { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ProdutoPreco { get; set; }
        public int ProdutoQuantidade { get; set; }

        //EF
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public ICollection<CarrinhoItem> CarrinhoItems { get; set; } = new List<CarrinhoItem>();
    }
}
