using System.ComponentModel.DataAnnotations;

namespace WS.VirtualStore.Api.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [MaxLength(100)]
        public string UsuarioNome { get; set; } = string.Empty;

        //EF
        public Carrinho? Carrinho { get; set; } 
    }
}
