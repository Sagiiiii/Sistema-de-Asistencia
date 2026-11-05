using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtInfraccionConfiguration : IEntityTypeConfiguration<PtInfraccion>
    {
        public void Configure(EntityTypeBuilder<PtInfraccion> builder)
        {
            builder.HasKey(e => e.IdInfraccion).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Gravedad).HasComment("LEVE = 1, GRAVE = 2, MUY GRAVE = 3");
        }
    }
}
