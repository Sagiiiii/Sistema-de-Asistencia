using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtCategoriaEvaluacionConfiguration : IEntityTypeConfiguration<PtCategoriaEvaluacion>
    {
        public void Configure(EntityTypeBuilder<PtCategoriaEvaluacion> builder)
        {
            builder.HasKey(e => e.IdCategoriaEvaluacion).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1; HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        }
    }
}
