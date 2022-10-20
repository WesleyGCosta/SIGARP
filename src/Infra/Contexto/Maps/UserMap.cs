using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Contexto.Maps
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasColumnType("varchar(50)");
            builder.Property(u => u.LastName).IsRequired().HasColumnType("varchar(100)");
        }
    }
}
