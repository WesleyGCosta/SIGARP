using Dominio.Enums;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Item
    {
        public int CodigoItem { get; private set; }
        public int CodigoAta { get; private set; }
        public int AnoAta { get; private set; }
        public ETipo Tipo { get; private set; }
        public string Descricao { get; private set; }
        public string Marca { get; private set; }
        public string UnidadeAquisicao { get; private set; }
        public int ConsumoEstimado { get; private set; }
        public decimal PrecoMercado { get; private set; }
        public decimal PrecoRegistrado { get; private set; }
        public bool Ativo { get; private set; }

        public Ata Ata { get; private set; }
        public IEnumerable<ItemParticipante> Participantes { get; private set; }
        public IEnumerable<Detentora> Detentoras { get; private set; }
    }
}
