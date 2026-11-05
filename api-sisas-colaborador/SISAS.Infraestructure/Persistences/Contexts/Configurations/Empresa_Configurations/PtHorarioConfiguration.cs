using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtHorarioConfiguration : IEntityTypeConfiguration<PtHorario>
    {
        public void Configure(EntityTypeBuilder<PtHorario> builder)
        {
            builder.HasKey(e => e.IdHorario).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Tipo).HasComment("TIEMPO COMPLETO = 1, MEDIO TIEMPO = 2");
            builder.Property(e => e.Turno).HasComment("MAÑANA = 1, TARDE = 2, NOCHE = 3");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(d => d.HorarioGlobal).WithMany(p => p.PtHorarios).HasConstraintName("pt_horario_ibfk_1");
        }
    }
}
