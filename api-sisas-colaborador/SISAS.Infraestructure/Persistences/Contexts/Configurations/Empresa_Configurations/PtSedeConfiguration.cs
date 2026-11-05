using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtSedeConfiguration : IEntityTypeConfiguration<PtSede>
    {
        public void Configure(EntityTypeBuilder<PtSede> builder)
        {
            builder.HasKey(e => e.IdSede).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO =2, DESHABILITADO = 3");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.Empresa).WithMany(p => p.PtSedes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_sede_ibfk_1");
        }
    }
}
