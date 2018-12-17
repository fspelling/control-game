using ControlGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Infra.Persistence.Map
{
    public class PlataformaMap : EntityTypeConfiguration<Plataforma>
    {
        public PlataformaMap()
        {
            ToTable("Plataforma");

            Property(p => p.Nome).HasMaxLength(50).IsRequired().HasColumnName("Nome");
        }
    }
}
