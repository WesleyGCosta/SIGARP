using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Contexto.Maps
{
    public class DetentoraMap : IEntityTypeConfiguration<Detentora>
    {
        public void Configure(EntityTypeBuilder<Detentora> builder)
        {
            builder.ToTable("Detentoras");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Cnpj).IsRequired().HasColumnType("Varchar(18)");
            builder.Property(d => d.RazaoSocial).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(d => d.NomeFantasia).HasColumnType("Varchar(100)");
            builder.Property(d => d.Email).HasColumnType("Varchar(100)");
            builder.Property(d => d.Telefone).HasColumnType("Varchar(15)");
            builder.Property(d => d.Pessoa).HasConversion(y => y.ToString(), y => (EPessoa)Enum.Parse(typeof(EPessoa), y)).HasMaxLength(10).IsRequired();
            builder.Property(d => d.Ativo).IsRequired().HasColumnType("bit");
        }
    }
}
