using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Contexto.Maps
{
    public class AtaMap : IEntityTypeConfiguration<Ata>
    {
        public void Configure(EntityTypeBuilder<Ata> builder)
        {
            builder.ToTable("Atas");
            builder.HasKey(a => new {a.CodigoAta, a.AnoAta});
            builder.Property(a => a.NumeroProcesso).IsRequired().HasColumnType("varchar(25)");
            builder.Property(a => a.NumeroPregao).IsRequired().HasColumnType("varchar(25)");
            builder.Property(a => a.AnoPregao).IsRequired().HasColumnType("int");
            builder.Property(a => a.DataHomologacao).IsRequired().HasColumnType("date");
            builder.Property(a => a.DataPublicacaoDOE).IsRequired().HasColumnType("date");
            builder.Property(a => a.DataFinalVigencia).IsRequired().HasColumnType("date");
            builder.Property(a => a.ObjetoResumido).IsRequired().HasColumnType("text");
            builder.Property(a => a.Publicada).IsRequired().HasColumnType("bit");
            builder.Property(a => a.DataPublicacaoSistema).IsRequired().HasColumnType("date");
            builder.Property(a => a.Observacao).IsRequired().HasColumnType("text");
            builder.Property(a => a.LimiteAdesao).IsRequired().HasColumnType("float");
        }
    }
}
