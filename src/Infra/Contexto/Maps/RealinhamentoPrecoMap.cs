using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contexto.Maps
{
    public class RealinhamentoPrecoMap : IEntityTypeConfiguration<RealinhamentoPreco>
    {
        public void Configure(EntityTypeBuilder<RealinhamentoPreco> builder)
        {
            builder.ToTable("RealinhamentosPrecos");
            builder.HasKey(x => x.Id);
            builder.Property(r => r.DataRegistro).IsRequired().HasColumnType("date"); ;
            builder.Property(r => r.PrecoMercado).IsRequired().HasColumnType("decimal(15,2)"); ;
            builder.Property(r => r.PrecoRegistrado).IsRequired().HasColumnType("decimal(15,2)"); ;
            builder.Property(r => r.PrecoAtual).IsRequired().HasColumnType("bit"); ;
            builder.Property(r => r.Justificativa).IsRequired().HasColumnType("varchar(250)");

            builder.HasOne(i => i.Item).WithMany(a => a.RealinhamentosPrecos).HasForeignKey(i => i.ItemId);
        }
    }
}
