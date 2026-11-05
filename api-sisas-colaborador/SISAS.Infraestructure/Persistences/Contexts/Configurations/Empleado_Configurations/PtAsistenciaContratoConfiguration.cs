using Microsoft.EntityFrameworkCore;
using SISAS.Domain.Entities.BD_EMPLEADO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empleado_Configurations
{
    public class PtAsistenciaContratoConfiguration : IEntityTypeConfiguration<PtAsistenciaContrato>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PtAsistenciaContrato> builder)
        {
            builder.HasKey(e => e.IdAsistenciaContrato).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, ASISTIÓ = 2, FALTÓ = 3, TARDE = 4, JUSTIFICADO = 5");

            builder.HasOne(d => d.Contrato).WithMany(p => p.PtAsistenciaContratos).HasConstraintName("pt_asistencia_contrato_ibfk_1");

            builder.HasOne(d => d.HorarioContrato).WithMany(p => p.PtAsistenciaContratos).HasConstraintName("pt_asistencia_contrato_ibfk_2");
        }
    }
}
