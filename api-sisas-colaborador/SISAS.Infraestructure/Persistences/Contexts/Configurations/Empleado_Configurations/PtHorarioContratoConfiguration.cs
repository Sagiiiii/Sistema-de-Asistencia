using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtHorarioContratoConfiguration : IEntityTypeConfiguration<PtHorarioContrato>
    {
        public void Configure(EntityTypeBuilder<PtHorarioContrato> builder)
        {
            builder.HasKey(e => e.IdHorarioContrato).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Dias).HasComment("DÍAS DE LA SEMANA (LUNES = 1, ..., DOMINGO = 7)");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Prioridad).HasComment("1, 2, 3, ETC ");
            builder.Property(e => e.Tipo).HasComment("PENDIENTE = 1, ORDINARIO = 2, EXTRAORDINARIO = 3");
            builder.Property(e => e.TipoContrato).HasComment("PENDIENTE = 1, PLANILLA = 2, HONORARIOS = 3");
            builder.Property(e => e.Turno).HasComment("MAÑANA = 1, TARDE = 2, NOCHE = 3");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.Contrato).WithMany(p => p.PtHorarioContratos).HasConstraintName("pt_horario_contrato_ibfk_1");

            builder.HasOne(d => d.Horario).WithMany(p => p.PtHorarioContratos).HasConstraintName("pt_horario_contrato_ibfk_2");
        }
    }
}
