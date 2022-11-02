using System;

namespace Domain.Entities
{
    public class RealinhamentoPreco
    {
        public RealinhamentoPreco(
            Guid id, 
            Guid itemId, 
            DateTime dataRegistro, 
            decimal precoMercado, 
            decimal precoRegistrado, 
            bool precoAtual, 
            string justificativa)
        {
            Id = id;
            ItemId = itemId;
            DataRegistro = dataRegistro;
            PrecoMercado = precoMercado;
            PrecoRegistrado = precoRegistrado;
            PrecoAtual = precoAtual;
            Justificativa = justificativa;
        }

        public Guid Id { get; private set; }
        public Guid ItemId { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public decimal PrecoMercado { get; private set; }
        public decimal PrecoRegistrado { get; private set; }
        public bool PrecoAtual { get; private set; }
        public string Justificativa { get; private set; } 

        public Item Item { get; set; }
    }
}
