namespace Backend.Models
{
    public class Observacao
    {
        public int ObservacaoId { get; set; }
        public int PedidoId { get; set; }
        public string Texto { get; set; }

        // Propriedade de navegação
        public Pedido Pedido { get; set; }
    }
}
