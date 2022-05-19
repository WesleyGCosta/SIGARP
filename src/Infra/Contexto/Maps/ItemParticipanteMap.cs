using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Contexto.Maps
{
    public class ItemParticipanteMap : IEntityTypeConfiguration<ItemParticipante>
    {
        public void Configure(EntityTypeBuilder<ItemParticipante> builder)
        {
            builder.ToTable("ItensParticipantes");
            builder.HasKey(i => new { i.CodigoAta, i.AnoAta });

        }
    }
}
