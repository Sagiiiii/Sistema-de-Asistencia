using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtConvalidacionEvaluacionConfiguration : IEntityTypeConfiguration<PtConvalidacionEvaluacion>
    {
        public void Configure(EntityTypeBuilder<PtConvalidacionEvaluacion> builder)
        {
            builder.HasKey(e => e.IdConvalidacionEvaluacion).HasName("PRIMARY");

            builder.HasOne(d => d.EvaluacionGlobal).WithMany(p => p.PtConvalidacionEvaluacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_convalidacion_evaluacion_ibfk_1");

            builder.HasOne(d => d.Evaluacion).WithMany(p => p.PtConvalidacionEvaluacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_convalidacion_evaluacion_ibfk_2");
        }
    }
}
