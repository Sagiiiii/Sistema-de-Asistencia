using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtContratoEvaluacionGlobalCriterioConfiguration : IEntityTypeConfiguration<PtContratoEvaluacionGlobalCriterio>
    {
        public void Configure(EntityTypeBuilder<PtContratoEvaluacionGlobalCriterio> builder)
        {
            builder.HasKey(e => e.IdContratoEvaluacionGlobalCriterio).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.ContratoEvaluacionGlobal).WithMany(p => p.PtContratoEvaluacionGlobalCriterios).HasConstraintName("pt_contrato_evaluacion_global_criterio_ibfk_1");

            builder.HasOne(d => d.Criterio).WithMany(p => p.PtContratoEvaluacionGlobalCriterios).HasConstraintName("pt_contrato_evaluacion_global_criterio_ibfk_2");
        }
    }
}
