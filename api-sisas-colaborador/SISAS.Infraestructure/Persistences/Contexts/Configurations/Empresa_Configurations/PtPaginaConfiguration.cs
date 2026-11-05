using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts.Configurations.Empresa_Configurations
{
    public class PtPaginaConfiguration : IEntityTypeConfiguration<PtPagina>
    {
        public void Configure(EntityTypeBuilder<PtPagina> builder)
        {
            builder.HasKey(e => e.IdPagina).HasName("PRIMARY");

            builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.Estado).HasComment("PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3");
            builder.Property(e => e.Tipo).HasComment("PENDIENTE = 1, INTERNO = 2, EXERNO = 3");
            builder.Property(e => e.TipoUri).HasComment(" \tPENDIENTE = 1, APP - FRONTEND = 2, API - BACKEND = 3 \t");

            builder.HasOne(d => d.Modulo).WithMany(p => p.PtPaginas).HasConstraintName("pt_pagina_ibfk_1");
        }
    }
}
