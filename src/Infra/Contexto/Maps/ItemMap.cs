using Dominio.Entidades;
using Dominio.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contexto.Maps
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Itens");
            builder.HasKey(i => i.CodigoItem);
            builder.Property(u => u.Tipo).HasConversion(y => y.ToString(), y => (ETipo)Enum.Parse(typeof(ETipo), y)).HasMaxLength(10).IsRequired();
            builder.Property(u => u.Descricao).IsRequired().HasColumnType("Varchar(8000)");
            builder.Property(u => u.Marca).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(u => u.UnidadeAquisicao).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(u => u.ConsumoEstimado).IsRequired().HasColumnType("int");
            builder.Property(u => u.PrecoMercado).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(u => u.PrecoRegistrado).IsRequired().HasColumnType("decimal(15,2)");
            builder.Property(u => u.Ativo).IsRequired().HasColumnType("bit");

        }
    }
}
