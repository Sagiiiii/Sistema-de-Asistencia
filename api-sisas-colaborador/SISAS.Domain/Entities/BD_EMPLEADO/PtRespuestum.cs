using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_respuesta")]
[Index("ContratoEvaluacionId", Name = "contrato_evaluacion_id")]
[Index("ContratoEvaluacionSegmentoId", Name = "contrato_evaluacion_segmento_id")]
public partial class PtRespuestum
{
    [Key]
    [Column("id_respuesta", TypeName = "int(11)")]
    public int IdRespuesta { get; set; }

    [Column("contrato_evaluacion_id", TypeName = "int(11)")]
    public int? ContratoEvaluacionId { get; set; }

    [Column("contrato_evaluacion_segmento_id", TypeName = "int(11)")]
    public int? ContratoEvaluacionSegmentoId { get; set; }

    [Column("codigo")]
    [StringLength(100)]
    public string? Codigo { get; set; }

    [Column("pregunta")]
    [StringLength(1000)]
    public string? Pregunta { get; set; }

    [Column("respuesta_correcta")]
    [StringLength(2)]
    public string? RespuestaCorrecta { get; set; }

    [Column("respuesta")]
    [StringLength(1)]
    public string? Respuesta { get; set; }

    [Column("puntaje")]
    [Precision(10, 4)]
    public decimal? Puntaje { get; set; }

    [Column("puntaje_porcentaje")]
    [Precision(10, 4)]
    public decimal? PuntajePorcentaje { get; set; }

    /// <summary>
    /// Porcentaje (de x/100%)
    /// </summary>
    [Column("valor_porcentaje")]
    [Precision(7, 4)]
    public decimal? ValorPorcentaje { get; set; }

    [Column("orden", TypeName = "int(11)")]
    public int? Orden { get; set; }

    [Column("estado", TypeName = "tinyint(4)")]
    public sbyte? Estado { get; set; }

    /// <summary>
    /// PENDIENTE = 1, CORRECTO = 2, INCORRECTO = 2, ANULADO = 3
    /// </summary>
    [Column("condicion", TypeName = "tinyint(4)")]
    public sbyte? Condicion { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

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

    [ForeignKey("ContratoEvaluacionId")]
    [InverseProperty("PtRespuesta")]
    public virtual PtContratoEvaluacion? ContratoEvaluacion { get; set; }

    [ForeignKey("ContratoEvaluacionSegmentoId")]
    [InverseProperty("PtRespuesta")]
    public virtual PtContratoEvaluacionSegmento? ContratoEvaluacionSegmento { get; set; }
}
