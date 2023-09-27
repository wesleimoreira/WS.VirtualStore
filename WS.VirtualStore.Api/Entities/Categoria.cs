using System.ComponentModel.DataAnnotations;

namespace WS.VirtualStore.Api.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [MaxLength(100)]
        public string CategoriaNome { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CategoriaIcone { get; set; } = string.Empty;

        //EF
        public ICollection<Produto>? Produtos { get; set; }
    }
}
