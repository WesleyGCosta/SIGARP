using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Contexto.Maps
{
    public class AtaMap : IEntityTypeConfiguration<Ata>
    {
        public void Configure(EntityTypeBuilder<Ata> builder)
        {
            builder.ToTable("Atas");
            builder.HasKey(a => new { a.CodigoAta, a.AnoAta });
            builder.Property(a => a.NumeroProcesso).IsRequired().HasColumnType("varchar(25)");
            builder.Property(a => a.NumeroPregao).IsRequired().HasColumnType("varchar(25)");
            builder.Property(a => a.AnoPregao).IsRequired().HasColumnType("int");
            builder.Property(a => a.TipoPregao).HasConversion(y => y.ToString(), y => (EPregao)Enum.Parse(typeof(EPregao), y)).HasMaxLength(20).IsRequired();
            builder.Property(a => a.DataHomologacao).IsRequired().HasColumnType("date");
            builder.Property(a => a.DataPublicacaoDOE).IsRequired().HasColumnType("date");
            builder.Property(a => a.DataFinalVigencia).IsRequired().HasColumnType("date");
            builder.Property(a => a.DataVencimentoAta).IsRequired().HasColumnType("date");
            builder.Property(a => a.ObjetoResumido).HasColumnType("text");
            builder.Property(a => a.Publicada).HasColumnType("bit");
            builder.Property(a => a.DataPublicacaoSistema).HasColumnType("date");
            builder.Property(a => a.DataCadastro).HasColumnType("date");
            builder.Property(a => a.DataAlteracao).HasColumnType("date");
            builder.Property(a => a.Observacao).HasColumnType("text");
            builder.Property(a => a.LimiteAdesao).HasColumnType("float");
        }
    }
}
