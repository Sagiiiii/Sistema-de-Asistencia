using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtServicioInternoConfiguration : IEntityTypeConfiguration<PtServicioInterno>
    {
        public void Configure(EntityTypeBuilder<PtServicioInterno> builder)
        {
            builder.HasKey(e => e.IdServicioInterno).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
        }
    }
}
