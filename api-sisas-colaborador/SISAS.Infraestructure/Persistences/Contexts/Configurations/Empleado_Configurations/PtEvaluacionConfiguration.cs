using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtEvaluacionConfiguration : IEntityTypeConfiguration<PtEvaluacion>
    {
        public void Configure(EntityTypeBuilder<PtEvaluacion> builder)
        {
            builder.HasKey(e => e.IdEvaluacion).HasName("PRIMARY");

            builder.Property(e => e.Condicion).HasComment("PENDIENTE = 1, RENDIDO = 2, NO RENDIDO = 3, CANCELADO = 4, ANULADO = 5, REPROGRAMADO = 6");
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.TipoPuntaje).HasComment("PENDIENTE = 1, PROMEDIO = 2; PUNTAJE = 3");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.CategoriaEvaluacion).WithMany(p => p.PtEvaluacions).HasConstraintName("pt_evaluacion_ibfk_1");
        }
    }
}
