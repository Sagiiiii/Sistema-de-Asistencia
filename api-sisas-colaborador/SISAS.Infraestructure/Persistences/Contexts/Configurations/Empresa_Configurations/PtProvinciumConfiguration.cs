using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtProvinciumConfiguration : IEntityTypeConfiguration<PtProvincium>
    {
        public void Configure(EntityTypeBuilder<PtProvincium> builder)
        {
            builder.HasKey(e => e.IdProvincia).HasName("PRIMARY");

            builder.HasOne(d => d.Departamento).WithMany(p => p.PtProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_provincia_ibfk_1");
        }
    }
}
