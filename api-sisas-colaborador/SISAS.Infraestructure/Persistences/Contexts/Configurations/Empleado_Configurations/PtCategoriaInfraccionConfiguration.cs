using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtCategoriaInfraccionConfiguration : IEntityTypeConfiguration<PtCategoriaInfraccion>
    {
        public void Configure(EntityTypeBuilder<PtCategoriaInfraccion> builder)
        {
            builder.HasKey(e => e.IdCategoriaInfraccion).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
