using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtAppEmpresaConfiguration : IEntityTypeConfiguration<PtAppEmpresa>
    {
        public void Configure(EntityTypeBuilder<PtAppEmpresa> builder)
        {
            builder.HasKey(e => e.IdAppEmpresa).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADAO = 2, DESHABILITADO = 3");

            builder.HasOne(d => d.App).WithMany(p => p.PtAppEmpresas).HasConstraintName("pt_app_empresa_ibfk_1");

            builder.HasOne(d => d.Empresa).WithMany(p => p.PtAppEmpresas).HasConstraintName("pt_app_empresa_ibfk_2");
        }
    }
}
