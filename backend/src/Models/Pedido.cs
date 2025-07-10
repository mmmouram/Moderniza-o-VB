using System.Collections.Generic;

namespace MyApp.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
        public ICollection<Observacao> Observacoes { get; set; }
        public ICollection<Bloqueio> Bloqueios { get; set; }
        public ICollection<NotaFiscal> NotasFiscais { get; set; }
    }
}
