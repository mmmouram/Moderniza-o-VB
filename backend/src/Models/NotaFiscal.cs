using System;

namespace MyApp.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }
        public Pedido Pedido { get; set; }
    }
}
