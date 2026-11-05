using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtEscalaConfiguration : IEntityTypeConfiguration<PtEscala>
    {
        public void Configure(EntityTypeBuilder<PtEscala> builder)
        {
            builder.HasKey(e => e.IdEscala).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
