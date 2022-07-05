using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Contexto.Maps
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Rua).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.Bairro).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(x => x.Numero).IsRequired().HasColumnType("int");
            builder.Property(x => x.Uf).IsRequired().HasColumnType("Varchar(5)");
            builder.Property(x => x.Municipio).IsRequired().HasColumnType("Varchar(50)");

            builder.HasOne(i => i.Detentora).WithMany(a => a.Enderecos);
        }
    }
}
