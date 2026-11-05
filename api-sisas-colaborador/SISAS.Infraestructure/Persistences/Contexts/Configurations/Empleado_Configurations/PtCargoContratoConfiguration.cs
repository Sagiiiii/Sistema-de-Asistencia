using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtCargoContratoConfiguration : IEntityTypeConfiguration<PtCargoContrato>
    {
        public void Configure(EntityTypeBuilder<PtCargoContrato> builder)
        {
            builder.HasKey(e => e.IdCargoContrato).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");

            builder.HasOne(d => d.Cargo).WithMany(p => p.PtCargoContratos).HasConstraintName("pt_cargo_contrato_ibfk_2");

            builder.HasOne(d => d.Contrato).WithMany(p => p.PtCargoContratos).HasConstraintName("pt_cargo_contrato_ibfk_1");
        }
    }
}
