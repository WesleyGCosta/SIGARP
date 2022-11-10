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
    public class OrdemFornecimentoMap : IEntityTypeConfiguration<OrdemFornecimento>
    {
        public void Configure(EntityTypeBuilder<OrdemFornecimento> builder)
        {
            builder.ToTable("OrdensFornecimentos");
            builder.HasKey(of => of.Id);
            builder.Property(of => of.DataFornecimento).IsRequired().HasColumnType("datetime");
            builder.Property(of => of.NumeroProcesso).IsRequired().HasColumnType("varchar(25)");
            builder.Property(of => of.Consumo).IsRequired().HasColumnType("int");

            //Relacionamento
            builder.HasOne(of => of.ProgramacaoConsumoParticipante).WithMany(a => a.OrdemFornecimentos);
        }
    }
}
