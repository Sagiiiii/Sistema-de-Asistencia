using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPLEADO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtCargoConfiguration : IEntityTypeConfiguration<PtCargo>
    {
        public void Configure(EntityTypeBuilder<PtCargo> builder)
        {
            builder.HasKey(e => e.IdCargo).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(d => d.Area).WithMany(p => p.PtCargos).HasConstraintName("pt_cargo_ibfk_1");
        }
    }
}
