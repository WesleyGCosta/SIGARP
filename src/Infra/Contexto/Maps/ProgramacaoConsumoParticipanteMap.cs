using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contexto.Maps
{
    public class ProgramacaoConsumoParticipanteMap : IEntityTypeConfiguration<ProgramacaoConsumoParticipante>
    {
        public void Configure(EntityTypeBuilder<ProgramacaoConsumoParticipante> builder)
        {
            builder.ToTable("ProgamacaoConsumoParticipoantes");
            builder.HasKey(p => new { p.CodigoAta, p.AnoAta});
            builder.Property(p => p.ConsumoEstimado).IsRequired().HasColumnType("int");
            builder.Property(p => p.Saldo).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(p => p.Aditivo).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(p => p.Transferido).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(p => p.SaldoAnterior).IsRequired().HasColumnType("decimal(15,2)");
        }
    }
}
