using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtSancionConfiguration : IEntityTypeConfiguration<PtSancion>
    {
        public void Configure(EntityTypeBuilder<PtSancion> builder)
        {
            builder.HasKey(e => e.IdSancion).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Tipo).HasComment("VERBAL = 1, SUMATORIA = 2, SUSPENSIÓN= 3");
        }
    }
}
