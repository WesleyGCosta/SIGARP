using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Contexto.Maps
{
    public class RealinhamentoPrecoMap : IEntityTypeConfiguration<RealinhamentoPreco>
    {
        public void Configure(EntityTypeBuilder<RealinhamentoPreco> builder)
        {
            builder.ToTable("RealinhamentosPrecos");
            builder.HasKey(x => x.Id);
            builder.Property(r => r.DataRegistro).IsRequired().HasColumnType("datetime");
            builder.Property(r => r.PrecoMercado).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(r => r.PrecoRegistrado).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(r => r.PrecoAtual).IsRequired().HasColumnType("bit");
            builder.Property(r => r.Justificativa).IsRequired().HasColumnType("varchar(250)");
            builder.Property(r => r.PrecoMercadoAnterior).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(r => r.PrecoRegistradoAnterior).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(r => r.Usuario).IsRequired().HasColumnType("varchar(75)");

            builder.HasOne(i => i.Item).WithMany(a => a.RealinhamentosPrecos).HasForeignKey(i => i.ItemId);
        }
    }
}
