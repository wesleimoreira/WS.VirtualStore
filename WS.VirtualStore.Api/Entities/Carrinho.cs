namespace WS.VirtualStore.Api.Entities
{
    public class Carrinho
    {
        public int CarrinhoId { get; set; }
        public int UsuarioId { get; set; }

        //EF
        public ICollection<CarrinhoItem> CarrinhoItems { get; set; } = new List<CarrinhoItem>();
    }
}
