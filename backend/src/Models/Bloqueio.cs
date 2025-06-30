namespace Backend.Models
{
    public class Bloqueio
    {
        public int BloqueioId { get; set; }
        public int PedidoId { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
        public string Observacao { get; set; }
        
        // Propriedade de navegação
        public Pedido Pedido { get; set; }
    }
}
