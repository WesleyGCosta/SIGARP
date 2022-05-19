using Dominio.Entidades;
using Dominio.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Contexto.Maps
{
    public class UnidadeAdministrativaMap : IEntityTypeConfiguration<UnidadeAdministrativa>
    {
        public void Configure(EntityTypeBuilder<UnidadeAdministrativa> builder)
        {
            builder.ToTable("UnidadesAdministrativas");
            builder.HasKey(u => u.CodigoUnidadeAdministrativa);
            builder.Property(u => u.NomeUnidadeAdministrativa).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(u => u.Sigla).IsRequired().HasColumnType("Varchar(10)");
            builder.Property(u => u.OrgaoEx).IsRequired().HasColumnType("bit");
            builder.Property(u => u.UnidadeDaFederacao).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(u => u.EsferaAdministrativa).HasConversion(y => y.ToString(), y => (EhEsferaAdministrativa)Enum.Parse(typeof(EhEsferaAdministrativa), y)).HasMaxLength(15).IsRequired();
            builder.Property(u => u.Ativo).IsRequired().HasColumnType("bit");
        }
    }
}
