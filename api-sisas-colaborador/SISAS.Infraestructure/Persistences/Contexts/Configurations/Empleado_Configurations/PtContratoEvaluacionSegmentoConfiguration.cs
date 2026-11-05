using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtContratoEvaluacionSegmentoConfiguration : IEntityTypeConfiguration<PtContratoEvaluacionSegmento>
    {
        public void Configure(EntityTypeBuilder<PtContratoEvaluacionSegmento> builder)
        {
            builder.HasKey(e => e.IdContratoEvaluacionSegmento).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.ContratoEvaluacion).WithMany(p => p.PtContratoEvaluacionSegmentos).HasConstraintName("pt_contrato_evaluacion_segmento_ibfk_1");

            builder.HasOne(d => d.Segmento).WithMany(p => p.PtContratoEvaluacionSegmentos).HasConstraintName("pt_contrato_evaluacion_segmento_ibfk_2");
        }
    }
}
