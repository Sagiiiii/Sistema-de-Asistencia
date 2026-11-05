using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_evaluacion")]
[Index("CategoriaEvaluacionId", Name = "categoria_evaluacion_id")]
public partial class PtEvaluacion
{
    [Key]
    [Column("id_evaluacion", TypeName = "int(11)")]
    public int IdEvaluacion { get; set; }

    [Column("categoria_evaluacion_id", TypeName = "int(11)")]
    public int? CategoriaEvaluacionId { get; set; }

    [Column("ciclo_lectivo_id", TypeName = "int(11)")]
    public int? CicloLectivoId { get; set; }

    [Column("periodo_id", TypeName = "int(11)")]
    public int? PeriodoId { get; set; }

    [Column("unidad_id", TypeName = "int(11)")]
    public int? UnidadId { get; set; }

    [Column("codigo")]
    [StringLength(100)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("nombre_corto")]
    [StringLength(100)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

    [Column("year", TypeName = "int(11)")]
    public int Year { get; set; }

    [Column("cantidad_preguntas", TypeName = "int(11)")]
    public int? CantidadPreguntas { get; set; }

    [Column("inicio", TypeName = "datetime")]
    public DateTime? Inicio { get; set; }

    [Column("fin", TypeName = "datetime")]
    public DateTime? Fin { get; set; }

    [Column("duracion", TypeName = "time")]
    public TimeOnly? Duracion { get; set; }

    [Column("cantidad_segmentos", TypeName = "int(11)")]
    public int? CantidadSegmentos { get; set; }

    [Column("puntaje")]
    [Precision(10, 4)]
    public decimal? Puntaje { get; set; }

    /// <summary>
    /// PENDIENTE = 1, PROMEDIO = 2; PUNTAJE = 3
    /// </summary>
    [Column("tipo_puntaje", TypeName = "int(11)")]
    public int? TipoPuntaje { get; set; }

    [Column("detalles")]
    [StringLength(1000)]
    public string? Detalles { get; set; }

    [Column("instrucciones", TypeName = "text")]
    public string? Instrucciones { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "tinyint(4)")]
    public sbyte? Estado { get; set; }

    /// <summary>
    /// PENDIENTE = 1, RENDIDO = 2, NO RENDIDO = 3, CANCELADO = 4, ANULADO = 5, REPROGRAMADO = 6
    /// </summary>
    [Column("condicion", TypeName = "tinyint(4)")]
    public sbyte? Condicion { get; set; }

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

    [ForeignKey("CategoriaEvaluacionId")]
    [InverseProperty("PtEvaluacions")]
    public virtual PtCategoriaEvaluacion? CategoriaEvaluacion { get; set; }

    [InverseProperty("Evaluacion")]
    public virtual ICollection<PtContratoEvaluacion> PtContratoEvaluacions { get; set; } = new List<PtContratoEvaluacion>();

    [InverseProperty("Evaluacion")]
    public virtual ICollection<PtConvalidacionEvaluacion> PtConvalidacionEvaluacions { get; set; } = new List<PtConvalidacionEvaluacion>();

    [InverseProperty("Evaluacion")]
    public virtual ICollection<PtSegmento> PtSegmentos { get; set; } = new List<PtSegmento>();
}
