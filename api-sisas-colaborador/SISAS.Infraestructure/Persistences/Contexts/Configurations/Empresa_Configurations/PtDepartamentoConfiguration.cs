using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtDepartamentoConfiguration : IEntityTypeConfiguration<PtDepartamento>
    {
        public void Configure(EntityTypeBuilder<PtDepartamento> builder)
        {
            builder.HasKey(e => e.IdDepartamento).HasName("PRIMARY");
        }
    }
}
