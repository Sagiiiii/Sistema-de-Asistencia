using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtAulaConfiguration : IEntityTypeConfiguration<PtAula>
    {
        public void Configure(EntityTypeBuilder<PtAula> builder)
        {
            builder.HasKey(e => e.IdAula).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Dimensiones).HasComment("medidas en metros: ancho, largo y área");
            builder.Property(e => e.Tipo).HasComment("Tipo de aula: (Salón de clases, Sala de Cómputo, etc)");

            builder.HasOne(d => d.Pabellon).WithMany(p => p.PtAulas).HasConstraintName("pt_aula_ibfk_1");
        }
    }
}
