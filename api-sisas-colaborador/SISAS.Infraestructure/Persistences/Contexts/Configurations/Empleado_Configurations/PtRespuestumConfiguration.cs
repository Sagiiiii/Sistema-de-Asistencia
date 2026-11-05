using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtRespuestumConfiguration : IEntityTypeConfiguration<PtRespuestum>
    {
        public void Configure(EntityTypeBuilder<PtRespuestum> builder)
        {
            builder.HasKey(e => e.IdRespuesta).HasName("PRIMARY");

            builder.Property(e => e.Condicion).HasComment("PENDIENTE = 1, CORRECTO = 2, INCORRECTO = 2, ANULADO = 3");
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.ValorPorcentaje).HasComment("Porcentaje (de x/100%)");

            builder.HasOne(d => d.ContratoEvaluacion).WithMany(p => p.PtRespuesta).HasConstraintName("pt_respuesta_ibfk_1");

            builder.HasOne(d => d.ContratoEvaluacionSegmento).WithMany(p => p.PtRespuesta).HasConstraintName("pt_respuesta_ibfk_2");
        }
    }
}
