using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtParentescoConfiguration : IEntityTypeConfiguration<PtParentesco>
    {
        public void Configure(EntityTypeBuilder<PtParentesco> builder)
        {
            builder.HasKey(e => e.IdParentesco).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
