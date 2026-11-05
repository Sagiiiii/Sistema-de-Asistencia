using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtCategoriaEvaluacionGlobalConfiguration : IEntityTypeConfiguration<PtCategoriaEvaluacionGlobal>
    {
        public void Configure(EntityTypeBuilder<PtCategoriaEvaluacionGlobal> builder)
        {
            builder.HasKey(e => e.IdCategoriaEvaluacionGlobal).HasName("PRIMARY");

            builder.Property(e => e.Estado).HasComment("PENDIENTE; HABILITADO, DESHABILITADO");
        }
    }
}
