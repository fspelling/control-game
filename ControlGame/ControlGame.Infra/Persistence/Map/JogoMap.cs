using ControlGame.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControlGame.Infra.Persistence.Map
{
    public class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {
            ToTable("Jogo");

            Property(p => p.Nome).HasMaxLength(100).IsRequired();
            Property(p => p.Descricao).HasMaxLength(255).IsRequired();
            Property(p => p.Produtora).HasMaxLength(50);
            Property(p => p.Destribuidora).HasMaxLength(50);
            Property(p => p.Genero).HasMaxLength(50);
            Property(p => p.Site).HasMaxLength(200);
        }
    }
}
