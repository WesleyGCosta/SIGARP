using Domain.Enums;

namespace WebApp.ViewModels
{
    public class ItemViewModel
    {
        public int CodigoItem { get; set; }
        public int CodigoAta { get; set; }
        public int AnoAta { get; set; }
        public ETipo Tipo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string UnidadeAquisicao { get; set; }
        public int ConsumoEstimado { get; set; }
        public decimal PrecoMercado { get; set; }
        public decimal PrecoRegistrado { get; set; }
        public bool Ativo { get; set; }
    }
}
