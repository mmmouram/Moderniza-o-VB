namespace MyApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public Pedido Pedido { get; set; }
    }
}
