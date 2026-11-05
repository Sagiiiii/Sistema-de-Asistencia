using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtDocumentoConfiguration : IEntityTypeConfiguration<PtDocumento>
    {
        public void Configure(EntityTypeBuilder<PtDocumento> builder)
        {
            builder.HasKey(e => e.IdDocumento).HasName("PRIMARY");

            builder.Property(e => e.Accion).HasComment("CERTIFICA, HACE CONSTAR, ETC");
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.EmpleadoSustantivo).HasComment("SR., SRITA, LIC, ETC");
            builder.Property(e => e.EmpleadoTipoDocumento).HasComment("OTROS = 1, DNI = 2, LIBRETA ELECTORAL = 3, PASAPORTE = 4");
            builder.Property(e => e.Estado)
                .HasDefaultValueSql("'PENDIENTE'")
                .HasComment("PENDIENTE = 1, EXPEDIDO = 2, ANULADO = 3");
            builder.Property(e => e.Tipo).HasComment("CERTIFICADO = 1, CONSTANCIA = 2");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.CargoContrato).WithMany(p => p.PtDocumentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_documento_ibfk_cargo_contrato_id");

            builder.HasOne(d => d.Contrato).WithMany(p => p.PtDocumentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pt_documento_ibfk_contrato_id");
        }
    }
}
