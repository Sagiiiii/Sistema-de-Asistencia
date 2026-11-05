using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtCategoriaHorarioConfiguration : IEntityTypeConfiguration<PtCategoriaHorario>
    {
        public void Configure(EntityTypeBuilder<PtCategoriaHorario> builder)
        {
            builder.HasKey(e => e.IdCategoriaHorario).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        }
    }
}
