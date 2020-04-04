using QuickBuy.Dominio.Entidades.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }
        /// <summary>
        /// Pedido deve ter pelo menos um ou muitos itens de pedido
        /// </summary>

        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            if (!ItensPedido.Any())
            {
                mensagensValidacao.Add("Validação: Pedido não pode ficar sem Item de pedido.");
            }
            if (string.IsNullOrEmpty(Cep))
            {
                mensagensValidacao.Add("Validação: CEP é obrigatório.");
            }
        }
    }
}
