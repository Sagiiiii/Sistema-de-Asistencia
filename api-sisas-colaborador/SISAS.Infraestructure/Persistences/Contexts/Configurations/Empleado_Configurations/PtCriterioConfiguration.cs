using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtCriterioConfiguration : IEntityTypeConfiguration<PtCriterio>
    {
        public void Configure(EntityTypeBuilder<PtCriterio> builder)
        {
            builder.HasKey(e => e.IdCriterio).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE, HABILITADO, DESHABILITADO");
            builder.Property(e => e.Porcentaje).HasComment("Procentaje de valor o peso");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.EvaluacionGlobal).WithMany(p => p.PtCriterios).HasConstraintName("pt_criterio_ibfk_1");
        }
    }
}
