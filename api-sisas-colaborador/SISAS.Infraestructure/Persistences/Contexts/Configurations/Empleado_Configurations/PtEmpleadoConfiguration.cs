using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtEmpleadoConfiguration : IEntityTypeConfiguration<PtEmpleado>
    {
        public void Configure(EntityTypeBuilder<PtEmpleado> builder)
        {
            builder.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Genero).HasComment("1 = MASCULINO, 2 = FEMENINO, 3 = OTROS, 4 = PREFIERO NO DECIRLO");
            builder.Property(e => e.Sustantivo).HasComment("EL SR. , LA SRA., ETC");
            builder.Property(e => e.TipoDocumento).HasComment("DNI = 1, LIBRETA ELECTORAL = 2, PASAPORTE = 3, OTROS = 4, GENERADO POR EL SISTEMA = 5");
        }
    }
}
