namespace MyApp.Models
{
    public class Bloqueio
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Motivo { get; set; }
        public Pedido Pedido { get; set; }
    }
}
