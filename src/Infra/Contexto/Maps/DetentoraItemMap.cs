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
    public class DetentoraItemMap : IEntityTypeConfiguration<DetentoraItem>
    {
        public void Configure(EntityTypeBuilder<DetentoraItem> builder)
        {
            builder.ToTable("DetentorasItens");
            builder.HasKey(d => d.Id);

            //Relacionamentos
            builder.HasOne(d => d.Item).WithOne(i => i.DetentoraItem).HasForeignKey<DetentoraItem>(i => i.ItemId);
            builder.HasOne(i => i.Detentora).WithMany(a => a.DetentorasItens);
        }
    }
}
