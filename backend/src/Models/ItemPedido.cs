using System;

namespace Backend.Models
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataInclusao { get; set; }

        // Propriedade de navegação
        public Pedido Pedido { get; set; }
    }
}
