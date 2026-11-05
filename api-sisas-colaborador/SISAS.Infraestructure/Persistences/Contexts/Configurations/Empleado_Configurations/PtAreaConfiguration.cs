
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtAreaConfiguration : IEntityTypeConfiguration<PtArea>
    {
        public void Configure(EntityTypeBuilder<PtArea> builder)
        {


            builder.HasKey(e => e.Id)
                .HasName("PRIMARY");

            builder.Property(e => e.Id)
    .HasColumnName("id_area");

            builder.Property(e => e.AreaId)
                .HasComment("ÁREA PADRE");

            builder.Property(e => e.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("datetime")
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .ValueGeneratedOnAdd();

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(e => e.DeletedAt)
                .HasColumnName("deleted_At")
                .HasColumnType("datetime");

            builder.Property(e => e.Estado)
                .HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");

            builder.HasOne(d => d.Area)
                .WithMany(p => p.InverseArea)
                .HasConstraintName("pt_area_ibfk_1");
        }
    }
}