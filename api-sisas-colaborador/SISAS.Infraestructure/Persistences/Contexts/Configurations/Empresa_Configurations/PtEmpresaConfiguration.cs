using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtEmpresaConfiguration : IEntityTypeConfiguration<PtEmpresa>
    {
        public void Configure(EntityTypeBuilder<PtEmpresa> builder)
        {
            builder.HasKey(e => e.IdEmpresa).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(d => d.Distrito).WithMany(p => p.PtEmpresas).HasConstraintName("pt_empresa_ibfk_1");
        }
    }
}
