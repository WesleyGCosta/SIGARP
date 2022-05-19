using Dominio.Entidades;
using Infra.Contexto.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Ata> Atas { get; set; }
        public DbSet<Detentora> Detentoras { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<ItemParticipante> ItensParticipantes { get; set; }
        public DbSet<ProgramacaoConsumoParticipante> ProgramacaoConsumoParticipantes { get; set; }
        public DbSet<UnidadeAdministrativa> UnidadesAdministrativas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtaMap());
            modelBuilder.ApplyConfiguration(new DetentoraMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new ItemParticipanteMap());
            modelBuilder.ApplyConfiguration(new ProgramacaoConsumoParticipanteMap());
            modelBuilder.ApplyConfiguration(new UnidadeAdministrativaMap());
        }
    }
}
