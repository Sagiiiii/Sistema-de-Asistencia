using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtPabellonConfiguration : IEntityTypeConfiguration<PtPabellon>
    {
        public void Configure(EntityTypeBuilder<PtPabellon> builder)
        {
            builder.HasKey(e => e.IdPabellon).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(d => d.Sede).WithMany(p => p.PtPabellons).HasConstraintName("pt_pabellon_ibfk_1");
        }
    }
}
