using System.Collections.Generic;

namespace Backend.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public string NumeroPedido { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        
        // Relacionamentos
        public List<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
        public List<Observacao> Observacoes { get; set; } = new List<Observacao>();
        public List<Bloqueio> Bloqueios { get; set; } = new List<Bloqueio>();
        public List<NotaFiscal> NotasFiscais { get; set; } = new List<NotaFiscal>();
    }
}
