using System;

namespace Backend.Models
{
    public class NotaFiscal
    {
        public int NotaFiscalId { get; set; }
        public int PedidoId { get; set; }
        public string NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }
        public decimal ValorNota { get; set; }

        // Propriedade de navegação
        public Pedido Pedido { get; set; }
    }
}
