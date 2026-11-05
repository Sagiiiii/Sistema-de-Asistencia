using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_contrato_evaluacion_global_criterio")]
[Index("ContratoEvaluacionGlobalId", Name = "contrato_evaluacion_global_id")]
[Index("CriterioId", Name = "criterio_id")]
public partial class PtContratoEvaluacionGlobalCriterio
{
    [Key]
    [Column("id_contrato_evaluacion_global_criterio", TypeName = "int(11)")]
    public int IdContratoEvaluacionGlobalCriterio { get; set; }

    [Column("contrato_evaluacion_global_id", TypeName = "int(11)")]
    public int? ContratoEvaluacionGlobalId { get; set; }

    [Column("criterio_id", TypeName = "int(11)")]
    public int? CriterioId { get; set; }

    [Column("puntaje")]
    [Precision(10, 4)]
    public decimal? Puntaje { get; set; }

    [Column("puntaje_porcentaje")]
    [Precision(10, 4)]
    public decimal? PuntajePorcentaje { get; set; }

    [Column("orden", TypeName = "int(11)")]
    public int? Orden { get; set; }

    [Column("estado", TypeName = "tinyint(4)")]
    public sbyte? Estado { get; set; }

    [Column("condicion", TypeName = "tinyint(4)")]
    public sbyte? Condicion { get; set; }

    [Column("detalles")]
    [StringLength(1000)]
    public string? Detalles { get; set; }

    [Column("created_by")]
    [StringLength(100)]
    public string? CreatedBy { get; set; }

    [Column("updated_by")]
    [StringLength(100)]
    public string? UpdatedBy { get; set; }

    [Column("deleted_by")]
    [StringLength(100)]
    public string? DeletedBy { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ContratoEvaluacionGlobalId")]
    [InverseProperty("PtContratoEvaluacionGlobalCriterios")]
    public virtual PtContratoEvaluacionGlobal? ContratoEvaluacionGlobal { get; set; }

    [ForeignKey("CriterioId")]
    [InverseProperty("PtContratoEvaluacionGlobalCriterios")]
    public virtual PtCriterio? Criterio { get; set; }
}
