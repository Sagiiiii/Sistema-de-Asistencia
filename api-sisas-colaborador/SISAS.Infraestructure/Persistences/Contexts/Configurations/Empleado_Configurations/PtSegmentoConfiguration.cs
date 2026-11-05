using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtSegmentoConfiguration : IEntityTypeConfiguration<PtSegmento>
    {
        public void Configure(EntityTypeBuilder<PtSegmento> builder)
        {
            builder.HasKey(e => e.IdSegmento).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Porcentaje).HasComment("Procentaje de valor o peso");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.Evaluacion).WithMany(p => p.PtSegmentos).HasConstraintName("pt_segmento_ibfk_1");
        }
    }
}
