using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtHorarioGlobalConfiguration : IEntityTypeConfiguration<PtHorarioGlobal>
    {
        public void Configure(EntityTypeBuilder<PtHorarioGlobal> builder)
        {
            builder.HasKey(e => e.IdHorarioGlobal).HasName("PRIMARY");

            builder.ToTable("pt_horario_global", tb => tb.HasComment("Guarda horarios en global"));

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Tipo).HasComment("TIEMPO COMPLETO = 1, MEDIO TIEMPO = 2");
            builder.Property(e => e.Turno).HasComment("MAÑANA = 1, TARDE = 2, NOCHE = 3");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        }
    }
}
