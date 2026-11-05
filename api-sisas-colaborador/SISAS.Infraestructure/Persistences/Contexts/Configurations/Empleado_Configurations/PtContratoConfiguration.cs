using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtContratoConfiguration : IEntityTypeConfiguration<PtContrato>
    {
        public void Configure(EntityTypeBuilder<PtContrato> builder)
        {
            builder.HasKey(e => e.IdContrato).HasName("PRIMARY");

            builder.Property(e => e.Asignatura).HasComment("Asignatura principal que dicta el docente");
            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Nivel).HasComment("Nivel principal que dicta el docente");
            builder.Property(e => e.TipoContrato).HasComment("PENDIENTE = 1, PLANILLA = 2, HONORARIOS = 3");
            builder.Property(e => e.TipoEmpleado).HasComment("PENDIENTE = 1, DOCENTE = 2, ADMINISTRATIVO = 3");
            builder.Property(e => e.TipoHorario).HasComment("PENDIENTE = 1, TIEMPO COMPLETO = 2, MEDIO TIEMPO = 3");
            builder.Property(e => e.TurnoHorario).HasComment("PENDIENTE = 1, MAÑANA = 2, TARDE = 3");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.Empleado).WithMany(p => p.PtContratoEmpleados).HasConstraintName("pt_contrato_ibfk_1");

            builder.HasOne(d => d.EmpleadoIdContratanteNavigation).WithMany(p => p.PtContratoEmpleadoIdContratanteNavigations).HasConstraintName("pt_contrato_ibfk_4");

            builder.HasOne(d => d.Escala).WithMany(p => p.PtContratos).HasConstraintName("pt_contrato_ibfk_3");
        }
    }
}
