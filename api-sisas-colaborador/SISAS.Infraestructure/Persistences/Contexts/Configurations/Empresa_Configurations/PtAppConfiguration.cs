using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtAppConfiguration : IEntityTypeConfiguration<PtApp>
    {
        public void Configure(EntityTypeBuilder<PtApp> builder)
        {
            builder.HasKey(e => e.IdApp).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
