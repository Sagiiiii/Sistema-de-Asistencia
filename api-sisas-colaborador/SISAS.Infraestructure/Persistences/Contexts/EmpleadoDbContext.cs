using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SISAS.Domain.Entities.BD_EMPLEADO;

namespace SISAS.Infraestructure.Persistences.Contexts;

public partial class EmpleadoDbContext : DbContext
{
    public EmpleadoDbContext(DbContextOptions<EmpleadoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PtArea> PtAreas { get; set; }

    public virtual DbSet<PtAsistenciaContrato> PtAsistenciaContratos { get; set; }

    public virtual DbSet<PtCargo> PtCargos { get; set; }

    public virtual DbSet<PtCargoContrato> PtCargoContratos { get; set; }

    public virtual DbSet<PtCategoriaEvaluacion> PtCategoriaEvaluacions { get; set; }

    public virtual DbSet<PtCategoriaEvaluacionGlobal> PtCategoriaEvaluacionGlobals { get; set; }

    public virtual DbSet<PtCategoriaHorario> PtCategoriaHorarios { get; set; }

    public virtual DbSet<PtCategoriaInfraccion> PtCategoriaInfraccions { get; set; }

    public virtual DbSet<PtContrato> PtContratos { get; set; }

    public virtual DbSet<PtContratoEvaluacion> PtContratoEvaluacions { get; set; }

    public virtual DbSet<PtContratoEvaluacionGlobal> PtContratoEvaluacionGlobals { get; set; }

    public virtual DbSet<PtContratoEvaluacionGlobalCriterio> PtContratoEvaluacionGlobalCriterios { get; set; }

    public virtual DbSet<PtContratoEvaluacionSegmento> PtContratoEvaluacionSegmentos { get; set; }

    public virtual DbSet<PtConvalidacionEvaluacion> PtConvalidacionEvaluacions { get; set; }

    public virtual DbSet<PtCriterio> PtCriterios { get; set; }

    public virtual DbSet<PtDocumento> PtDocumentos { get; set; }

    public virtual DbSet<PtEmpleado> PtEmpleados { get; set; }

    public virtual DbSet<PtEscala> PtEscalas { get; set; }

    public virtual DbSet<PtEvaluacion> PtEvaluacions { get; set; }

    public virtual DbSet<PtEvaluacionGlobal> PtEvaluacionGlobals { get; set; }

    public virtual DbSet<PtHorario> PtHorarios { get; set; }

    public virtual DbSet<PtHorarioContrato> PtHorarioContratos { get; set; }

    public virtual DbSet<PtInfraccion> PtInfraccions { get; set; }

    public virtual DbSet<PtRespuestum> PtRespuesta { get; set; }

    public virtual DbSet<PtSancion> PtSancions { get; set; }

    public virtual DbSet<PtSegmento> PtSegmentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder
        .UseCollation("utf8mb4_general_ci")
        .HasCharSet("utf8mb4");

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpleadoDbContext).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
      typeof(EmpleadoDbContext).Assembly,
      type => type.Namespace != null &&
              type.Namespace.Contains("Empleado_Configurations")
  );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
