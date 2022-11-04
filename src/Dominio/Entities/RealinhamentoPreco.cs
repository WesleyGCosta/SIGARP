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
            string justificativa,
            decimal precoMercadoAnterior,
            decimal precoRegistradoAnterior,
            string usuario)
        {
            Id = id;
            ItemId = itemId;
            DataRegistro = dataRegistro;
            PrecoMercado = precoMercado;
            PrecoRegistrado = precoRegistrado;
            PrecoAtual = precoAtual;
            Justificativa = justificativa;
            PrecoMercadoAnterior = precoMercadoAnterior;
            PrecoRegistradoAnterior = precoRegistradoAnterior;
            Usuario = usuario;
        }

        public Guid Id { get; private set; }
        public Guid ItemId { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public decimal PrecoMercado { get; private set; }
        public decimal PrecoRegistrado { get; private set; }
        public bool PrecoAtual { get; private set; }
        public decimal PrecoMercadoAnterior { get; private set; }
        public decimal PrecoRegistradoAnterior { get; private set; }
        public string Justificativa { get; private set; } 
        public string Usuario { get; private set; }

        public Item Item { get; set; }
    }
}
