using ControlGame.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ControlGame.Infra.Persistence.Map
{
    public class JogadorMap : EntityTypeConfiguration<Jogador>
    {
        public JogadorMap()
        {
            ToTable("Jogador");

            Property(p => p.Email.Endereco).HasMaxLength(200).IsRequired().HasColumnAnnotation("Index", new IndexAttribute("UK_JOGADOR_EMAIL") { IsUnique = true }).HasColumnName("Email");
            Property(p => p.Nome.PrimeiroNome).HasMaxLength(50).IsRequired().HasColumnName("PrimeiroNome");
            Property(p => p.Senha).IsRequired();
            Property(p => p.Status).IsRequired();
        }
    }
}
