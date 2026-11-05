using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtContratoEvaluacionGlobalConfiguration : IEntityTypeConfiguration<PtContratoEvaluacionGlobal>
    {
        public void Configure(EntityTypeBuilder<PtContratoEvaluacionGlobal> builder)
        {
            builder.HasKey(e => e.IdContratoEvaluacionGlobal).HasName("PRIMARY");

            builder.Property(e => e.Condicion).HasComment("PENDIENTE, APROBADO, DESAPROBADO");
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("'2023-01-01 10:00:00'");
            builder.Property(e => e.Estado).HasComment("PENDIENTE, TOMADO, NO TOMADO, CANCELADO, ANULADO");

            builder.HasOne(d => d.Contrato).WithMany(p => p.PtContratoEvaluacionGlobals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_contrato_evaluacion_global_ibfk_1");

            builder.HasOne(d => d.EvaluacionGlobal).WithMany(p => p.PtContratoEvaluacionGlobals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_contrato_evaluacion_global_ibfk_2");
        }
    }
}
