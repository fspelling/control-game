using ControlGame.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControlGame.Infra.Persistence
{
    public class ControlGameContext : DbContext
    {
        public IDbSet<Jogador> Jogadores { get; set; }

        public IDbSet<Plataforma> Plataformas { get; set; }

        public IDbSet<Jogo> Jogos { get; set; }

        public ControlGameContext() : base("ControlGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remover o plural no nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //remover os dados de forma em cascata, para que seja manualmente
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //setar o tipo string para varchar como default
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //setar o maximo de caracteres para o tamanho 100 como default
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //adicionar entidades mapeadas via assembly
            modelBuilder.Conventions.AddFromAssembly(typeof(ControlGameContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
