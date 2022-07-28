using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Contexto.Maps
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Itens");
            builder.HasKey(i => i.Id);

            //Propriedades
            builder.Property(i => i.NumeroItem).IsRequired().HasColumnType("int");
            builder.Property(i => i.Tipo).HasConversion(y => y.ToString(), y => (ETipo)Enum.Parse(typeof(ETipo), y)).HasMaxLength(10).IsRequired();
            builder.Property(i => i.Descricao).IsRequired().HasColumnType("Varchar(8000)");
            builder.Property(i => i.Marca).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(i => i.UnidadeAquisicao).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(i => i.ConsumoEstimado).IsRequired().HasColumnType("int");
            builder.Property(i => i.PrecoMercado).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(i => i.PrecoRegistrado).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(i => i.Ativo).IsRequired().HasColumnType("bit");

            //Relacionamento
            builder.HasOne(i => i.Ata).WithMany(a => a.Itens).HasForeignKey(i => new {i.CodigoAta, i.AnoAta});
        }
    }
}
