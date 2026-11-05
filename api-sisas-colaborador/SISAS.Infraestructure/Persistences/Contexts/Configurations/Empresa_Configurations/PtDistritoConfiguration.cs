using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtDistritoConfiguration : IEntityTypeConfiguration<PtDistrito>
    {
        public void Configure(EntityTypeBuilder<PtDistrito> builder)
        {
            builder.HasKey(e => e.IdDistrito).HasName("PRIMARY");

            builder.HasOne(d => d.Provincia).WithMany(p => p.PtDistritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_distrito_ibfk_1");
        }
    }
}
