using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_evaluacion_global")]
[Index("CategoriaEvaluacionGlobalId", Name = "categoria_evaluacion_global_id")]
[Index("CicloLectivoId", Name = "ciclo_lectivo_id")]
public partial class PtEvaluacionGlobal
{
    [Key]
    [Column("id_evaluacion_global", TypeName = "int(11)")]
    public int IdEvaluacionGlobal { get; set; }

    [Column("categoria_evaluacion_global_id", TypeName = "int(11)")]
    public int CategoriaEvaluacionGlobalId { get; set; }

    [Column("ciclo_lectivo_id", TypeName = "int(11)")]
    public int CicloLectivoId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
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

    [Column("cantidad_criterios", TypeName = "int(11)")]
    public int CantidadCriterios { get; set; }

    [Column("inicio", TypeName = "datetime")]
    public DateTime? Inicio { get; set; }

    [Column("fin", TypeName = "datetime")]
    public DateTime? Fin { get; set; }

    [Column("duracion", TypeName = "time")]
    public TimeOnly? Duracion { get; set; }

    /// <summary>
    /// PENDIENTE, PROMEDIO, PUNTAJE
    /// </summary>
    [Column("puntaje")]
    [Precision(10, 4)]
    public decimal? Puntaje { get; set; }

    [Column("tipo_puntaje")]
    [StringLength(50)]
    public string TipoPuntaje { get; set; } = null!;

    [Column("instrucciones")]
    public string? Instrucciones { get; set; }

    /// <summary>
    /// PENDIENTE, HABILITADO, DESHABILITADO
    /// </summary>
    [Column("estado")]
    [StringLength(50)]
    public string Estado { get; set; } = null!;

    /// <summary>
    /// PENDIENTE, RENDIDO, NO RENDIDO, CANCELADO, ANULADO, REPROGRAMADO
    /// </summary>
    [Column("condicion")]
    [StringLength(50)]
    public string Condicion { get; set; } = null!;

    [Column("tipo")]
    [StringLength(50)]
    public string Tipo { get; set; } = null!;

    [Column("detalles")]
    [StringLength(500)]
    public string? Detalles { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("CategoriaEvaluacionGlobalId")]
    [InverseProperty("PtEvaluacionGlobals")]
    public virtual PtCategoriaEvaluacionGlobal CategoriaEvaluacionGlobal { get; set; } = null!;

    [InverseProperty("EvaluacionGlobal")]
    public virtual ICollection<PtContratoEvaluacionGlobal> PtContratoEvaluacionGlobals { get; set; } = new List<PtContratoEvaluacionGlobal>();

    [InverseProperty("EvaluacionGlobal")]
    public virtual ICollection<PtConvalidacionEvaluacion> PtConvalidacionEvaluacions { get; set; } = new List<PtConvalidacionEvaluacion>();

    [InverseProperty("EvaluacionGlobal")]
    public virtual ICollection<PtCriterio> PtCriterios { get; set; } = new List<PtCriterio>();
}
