using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_contrato_evaluacion")]
[Index("ContratoId", Name = "contrato_id")]
[Index("EvaluacionId", Name = "evaluacion_id")]
public partial class PtContratoEvaluacion
{
    [Key]
    [Column("id_contrato_evaluacion", TypeName = "int(11)")]
    public int IdContratoEvaluacion { get; set; }

    [Column("contrato_id", TypeName = "int(11)")]
    public int? ContratoId { get; set; }

    [Column("evaluacion_id", TypeName = "int(11)")]
    public int? EvaluacionId { get; set; }

    [Column("codigo")]
    [StringLength(100)]
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
    /// PENDIENTE =1, TOMADO = 2, NO TOMADO = 3, CANCELADO = 4, ANULADO = 5
    /// </summary>
    [Column("estado", TypeName = "tinyint(4)")]
    public sbyte? Estado { get; set; }

    /// <summary>
    /// PENDIENTE = 1, APROBADO = 2, DESAPROBADO = 3
    /// </summary>
    [Column("condicion", TypeName = "tinyint(4)")]
    public sbyte? Condicion { get; set; }

    [Column("observacion")]
    [StringLength(1000)]
    public string? Observacion { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

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

    [ForeignKey("ContratoId")]
    [InverseProperty("PtContratoEvaluacions")]
    public virtual PtContrato? Contrato { get; set; }

    [ForeignKey("EvaluacionId")]
    [InverseProperty("PtContratoEvaluacions")]
    public virtual PtEvaluacion? Evaluacion { get; set; }

    [InverseProperty("ContratoEvaluacion")]
    public virtual ICollection<PtContratoEvaluacionSegmento> PtContratoEvaluacionSegmentos { get; set; } = new List<PtContratoEvaluacionSegmento>();

    [InverseProperty("ContratoEvaluacion")]
    public virtual ICollection<PtRespuestum> PtRespuesta { get; set; } = new List<PtRespuestum>();
}
