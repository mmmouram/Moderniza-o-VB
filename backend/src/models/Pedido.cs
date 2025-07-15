using System;
using System.Collections.Generic;

namespace MyApp.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Status { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal ValorTotal { get; set; }

        public ICollection<Item> Itens { get; set; }
        public ICollection<Observacao> Observacoes { get; set; }
        public ICollection<PedidoBloqueio> Bloqueios { get; set; }
        public ICollection<NotaFiscal> NotasFiscais { get; set; }
    }
}
