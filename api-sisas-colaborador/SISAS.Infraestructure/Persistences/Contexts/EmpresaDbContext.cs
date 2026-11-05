using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SISAS.Domain.Entities.BD_EMPRESA;

namespace SISAS.Infraestructure.Persistences.Contexts;

public partial class EmpresaDbContext : DbContext
{
    public EmpresaDbContext(DbContextOptions<EmpresaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PtApp> PtApps { get; set; }

    public virtual DbSet<PtAppEmpresa> PtAppEmpresas { get; set; }

    public virtual DbSet<PtAula> PtAulas { get; set; }

    public virtual DbSet<PtCategoriaHorario> PtCategoriaHorarios { get; set; }

    public virtual DbSet<PtCategoriaInfraccion> PtCategoriaInfraccions { get; set; }

    public virtual DbSet<PtDepartamento> PtDepartamentos { get; set; }

    public virtual DbSet<PtDistrito> PtDistritos { get; set; }

    public virtual DbSet<PtEmpresa> PtEmpresas { get; set; }

    public virtual DbSet<PtHorario> PtHorarios { get; set; }

    public virtual DbSet<PtHorarioGlobal> PtHorarioGlobals { get; set; }

    public virtual DbSet<PtInfraccion> PtInfraccions { get; set; }

    public virtual DbSet<PtModulo> PtModulos { get; set; }

    public virtual DbSet<PtPabellon> PtPabellons { get; set; }

    public virtual DbSet<PtPagina> PtPaginas { get; set; }

    public virtual DbSet<PtParentesco> PtParentescos { get; set; }

    public virtual DbSet<PtProvincium> PtProvincia { get; set; }

    public virtual DbSet<PtSancion> PtSancions { get; set; }

    public virtual DbSet<PtSede> PtSedes { get; set; }

    public virtual DbSet<PtServicioInterno> PtServicioInternos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpresaDbContext).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(
typeof(EmpresaDbContext).Assembly,
type => type.Namespace != null &&
        type.Namespace.Contains("Empresa_Configurations")
);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
