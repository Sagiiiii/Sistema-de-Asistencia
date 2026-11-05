using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_app_empresa")]
[Index("AppId", Name = "app_id")]
[Index("EmpresaId", Name = "empresa_id")]
public partial class PtAppEmpresa
{
    [Key]
    [Column("id_app_empresa", TypeName = "int(11)")]
    public int IdAppEmpresa { get; set; }

    [Column("app_id", TypeName = "int(11)")]
    public int? AppId { get; set; }

    [Column("empresa_id", TypeName = "int(11)")]
    public int? EmpresaId { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADAO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    [Column("fecha_inicio")]
    public DateOnly? FechaInicio { get; set; }

    [Column("hora_inicio", TypeName = "time")]
    public TimeOnly? HoraInicio { get; set; }

    [Column("fecha_fin")]
    public DateOnly? FechaFin { get; set; }

    [Column("hora_fin", TypeName = "time")]
    public TimeOnly? HoraFin { get; set; }

    [Column("detalles")]
    public string? Detalles { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("AppId")]
    [InverseProperty("PtAppEmpresas")]
    public virtual PtApp? App { get; set; }

    [ForeignKey("EmpresaId")]
    [InverseProperty("PtAppEmpresas")]
    public virtual PtEmpresa? Empresa { get; set; }
}
