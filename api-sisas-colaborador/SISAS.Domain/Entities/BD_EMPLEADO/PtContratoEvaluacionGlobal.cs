using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_contrato_evaluacion_global")]
[Index("ContratoId", Name = "contrato_id")]
[Index("EvaluacionGlobalId", Name = "evaluacion_global_id")]
public partial class PtContratoEvaluacionGlobal
{
    [Key]
    [Column("id_contrato_evaluacion_global", TypeName = "int(11)")]
    public int IdContratoEvaluacionGlobal { get; set; }

    [Column("contrato_id", TypeName = "int(11)")]
    public int ContratoId { get; set; }

    [Column("evaluacion_global_id", TypeName = "int(11)")]
    public int EvaluacionGlobalId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("puntaje")]
    [Precision(10, 4)]
    public decimal? Puntaje { get; set; }

    [Column("puntaje_porcentaje")]
    [Precision(7, 4)]
    public decimal? PuntajePorcentaje { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    /// <summary>
    /// PENDIENTE, TOMADO, NO TOMADO, CANCELADO, ANULADO
    /// </summary>
    [Column("estado")]
    [StringLength(50)]
    public string Estado { get; set; } = null!;

    /// <summary>
    /// PENDIENTE, APROBADO, DESAPROBADO
    /// </summary>
    [Column("condicion")]
    [StringLength(50)]
    public string? Condicion { get; set; }

    [Column("observaciones")]
    [StringLength(1000)]
    public string? Observaciones { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_by")]
    [StringLength(200)]
    public string? CreatedBy { get; set; }

    [Column("updated_by")]
    [StringLength(200)]
    public string? UpdatedBy { get; set; }

    [Column("deleted_by")]
    [StringLength(200)]
    public string? DeletedBy { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ContratoId")]
    [InverseProperty("PtContratoEvaluacionGlobals")]
    public virtual PtContrato Contrato { get; set; } = null!;

    [ForeignKey("EvaluacionGlobalId")]
    [InverseProperty("PtContratoEvaluacionGlobals")]
    public virtual PtEvaluacionGlobal EvaluacionGlobal { get; set; } = null!;

    [InverseProperty("ContratoEvaluacionGlobal")]
    public virtual ICollection<PtContratoEvaluacionGlobalCriterio> PtContratoEvaluacionGlobalCriterios { get; set; } = new List<PtContratoEvaluacionGlobalCriterio>();
}
