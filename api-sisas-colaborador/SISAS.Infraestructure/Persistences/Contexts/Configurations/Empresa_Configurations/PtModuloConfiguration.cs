using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtModuloConfiguration : IEntityTypeConfiguration<PtModulo>
    {
        public void Configure(EntityTypeBuilder<PtModulo> builder)
        {
            builder.HasKey(e => e.IdModulo).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(d => d.App).WithMany(p => p.PtModulos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_modulo_ibfk_1");
        }
    }
}
