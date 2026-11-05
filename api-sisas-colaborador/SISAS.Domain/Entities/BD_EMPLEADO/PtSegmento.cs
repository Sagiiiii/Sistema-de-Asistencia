using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_segmento")]
[Index("EvaluacionId", Name = "evaluacion_id")]
public partial class PtSegmento
{
    [Key]
    [Column("id_segmento", TypeName = "int(11)")]
    public int IdSegmento { get; set; }

    [Column("evaluacion_id", TypeName = "int(11)")]
    public int? EvaluacionId { get; set; }

    [Column("codigo")]
    [StringLength(100)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("nombre_corto")]
    [StringLength(100)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    /// <summary>
    /// Procentaje de valor o peso
    /// </summary>
    [Column("porcentaje")]
    [Precision(7, 4)]
    public decimal? Porcentaje { get; set; }

    [Column("puntaje")]
    [Precision(10, 4)]
    public decimal? Puntaje { get; set; }

    [Column("cantidad_preguntas", TypeName = "int(11)")]
    public int? CantidadPreguntas { get; set; }

    [Column("detalles")]
    [StringLength(1000)]
    public string? Detalles { get; set; }

    [Column("pregunta_inicio", TypeName = "int(11)")]
    public int? PreguntaInicio { get; set; }

    [Column("pregunta_fin", TypeName = "int(11)")]
    public int? PreguntaFin { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("EvaluacionId")]
    [InverseProperty("PtSegmentos")]
    public virtual PtEvaluacion? Evaluacion { get; set; }

    [InverseProperty("Segmento")]
    public virtual ICollection<PtContratoEvaluacionSegmento> PtContratoEvaluacionSegmentos { get; set; } = new List<PtContratoEvaluacionSegmento>();
}
