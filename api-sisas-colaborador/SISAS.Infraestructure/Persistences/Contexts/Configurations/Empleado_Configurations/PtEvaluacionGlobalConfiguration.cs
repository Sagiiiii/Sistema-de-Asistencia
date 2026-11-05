using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtEvaluacionGlobalConfiguration : IEntityTypeConfiguration<PtEvaluacionGlobal>
    {
        public void Configure(EntityTypeBuilder<PtEvaluacionGlobal> builder)
        {
            builder.HasKey(e => e.IdEvaluacionGlobal).HasName("PRIMARY");

            builder.Property(e => e.Condicion).HasComment("PENDIENTE, RENDIDO, NO RENDIDO, CANCELADO, ANULADO, REPROGRAMADO");
            builder.Property(e => e.Estado).HasComment("PENDIENTE, HABILITADO, DESHABILITADO");
            builder.Property(e => e.Puntaje).HasComment("PENDIENTE, PROMEDIO, PUNTAJE");

            builder.HasOne(d => d.CategoriaEvaluacionGlobal).WithMany(p => p.PtEvaluacionGlobals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_evaluacion_global_ibfk_1");
        }
    }
}
