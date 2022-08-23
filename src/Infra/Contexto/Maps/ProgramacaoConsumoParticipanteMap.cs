using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Contexto.Maps
{
    public class ProgramacaoConsumoParticipanteMap : IEntityTypeConfiguration<ProgramacaoConsumoParticipante>
    {
        public void Configure(EntityTypeBuilder<ProgramacaoConsumoParticipante> builder)
        {
            builder.ToTable("ProgamacaoConsumoParticipantes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ConsumoEstimado).IsRequired().HasColumnType("int");
            builder.Property(p => p.Saldo).IsRequired().HasColumnType("int");
            builder.Property(p => p.Transferido).IsRequired().HasColumnType("int");
            builder.Property(p => p.SaldoAnterior).IsRequired().HasColumnType("int");

            builder.HasOne(d => d.ParticipanteItem).WithOne(i => i.ProgramacoesConsumoParticipantes).HasForeignKey<ProgramacaoConsumoParticipante>(i => i.ParticipanteId);
        }
    }
}
