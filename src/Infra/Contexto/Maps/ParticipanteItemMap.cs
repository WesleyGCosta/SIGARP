using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Contexto.Maps
{
    public class ParticipanteItemMap : IEntityTypeConfiguration<ParticipanteItem>
    {
        public void Configure(EntityTypeBuilder<ParticipanteItem> builder)
        {
            builder.ToTable("ParticipantesItens");
            builder.HasKey(x => x.Id);

            //Relacionamentos
            builder.HasOne(i => i.Item).WithMany(a => a.ParticipantesItens);
            builder.HasOne(i => i.UnidadeAdministrativa).WithMany(a => a.ParticipantesItens);
        }
    }
}
