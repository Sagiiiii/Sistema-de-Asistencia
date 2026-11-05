using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_criterio")]
[Index("EvaluacionGlobalId", Name = "evaluacion_global_id")]
public partial class PtCriterio
{
    [Key]
    [Column("id_criterio", TypeName = "int(11)")]
    public int IdCriterio { get; set; }

    [Column("evaluacion_global_id", TypeName = "int(11)")]
    public int? EvaluacionGlobalId { get; set; }

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
    /// PENDIENTE, HABILITADO, DESHABILITADO
    /// </summary>
    [Column("estado")]
    [StringLength(50)]
    public string? Estado { get; set; }

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

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("EvaluacionGlobalId")]
    [InverseProperty("PtCriterios")]
    public virtual PtEvaluacionGlobal? EvaluacionGlobal { get; set; }

    [InverseProperty("Criterio")]
    public virtual ICollection<PtContratoEvaluacionGlobalCriterio> PtContratoEvaluacionGlobalCriterios { get; set; } = new List<PtContratoEvaluacionGlobalCriterio>();
}
