using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_contrato_evaluacion_segmento")]
[Index("ContratoEvaluacionId", Name = "contrato_evaluacion_id")]
[Index("SegmentoId", Name = "segmento_id")]
public partial class PtContratoEvaluacionSegmento
{
    [Key]
    [Column("id_contrato_evaluacion_segmento", TypeName = "int(11)")]
    public int IdContratoEvaluacionSegmento { get; set; }

    [Column("contrato_evaluacion_id", TypeName = "int(11)")]
    public int? ContratoEvaluacionId { get; set; }

    [Column("segmento_id", TypeName = "int(11)")]
    public int? SegmentoId { get; set; }

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

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ContratoEvaluacionId")]
    [InverseProperty("PtContratoEvaluacionSegmentos")]
    public virtual PtContratoEvaluacion? ContratoEvaluacion { get; set; }

    [InverseProperty("ContratoEvaluacionSegmento")]
    public virtual ICollection<PtRespuestum> PtRespuesta { get; set; } = new List<PtRespuestum>();

    [ForeignKey("SegmentoId")]
    [InverseProperty("PtContratoEvaluacionSegmentos")]
    public virtual PtSegmento? Segmento { get; set; }
}
