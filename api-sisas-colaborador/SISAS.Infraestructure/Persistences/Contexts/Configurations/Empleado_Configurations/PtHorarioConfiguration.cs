using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtHorarioConfiguration : IEntityTypeConfiguration<PtHorario>
    {
        public void Configure(EntityTypeBuilder<PtHorario> builder)
        {

            builder.HasKey(e => e.Id)
                .HasName("PRIMARY");

            builder.Property(e => e.Id)
    .HasColumnName("id_horario");

            builder.Property(e => e.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("datetime")
      .HasDefaultValueSql("CURRENT_TIMESTAMP")

      .ValueGeneratedOnAdd();
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Tipo).HasComment("TIEMPO COMPLETO = 1, MEDIO TIEMPO = 2");
            builder.Property(e => e.Turno).HasComment("MAÑANA = 1, TARDE = 2, NOCHE = 3");
            //builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();



            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_At")
                .HasColumnType("datetime");
        }


    }
}
