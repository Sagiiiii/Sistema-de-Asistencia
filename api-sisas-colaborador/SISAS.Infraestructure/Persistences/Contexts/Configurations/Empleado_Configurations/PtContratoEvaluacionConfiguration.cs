using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtContratoEvaluacionConfiguration : IEntityTypeConfiguration<PtContratoEvaluacion>
    {
        public void Configure(EntityTypeBuilder<PtContratoEvaluacion> builder)
        {
            builder.HasKey(e => e.IdContratoEvaluacion).HasName("PRIMARY");

            builder.Property(e => e.Condicion).HasComment("PENDIENTE = 1, APROBADO = 2, DESAPROBADO = 3");
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE =1, TOMADO = 2, NO TOMADO = 3, CANCELADO = 4, ANULADO = 5");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.Contrato).WithMany(p => p.PtContratoEvaluacions).HasConstraintName("pt_contrato_evaluacion_ibfk_1");

            builder.HasOne(d => d.Evaluacion).WithMany(p => p.PtContratoEvaluacions).HasConstraintName("pt_contrato_evaluacion_ibfk_2");
        }
    }
}
