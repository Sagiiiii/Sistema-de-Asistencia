using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_convalidacion_evaluacion")]
[Index("CicloLectivoId", Name = "ciclo_lectivo_id")]
[Index("EvaluacionGlobalId", Name = "evaluacion_global_id")]
[Index("EvaluacionId", Name = "evaluacion_id")]
public partial class PtConvalidacionEvaluacion
{
    [Key]
    [Column("id_convalidacion_evaluacion", TypeName = "int(11)")]
    public int IdConvalidacionEvaluacion { get; set; }

    [Column("evaluacion_global_id", TypeName = "int(11)")]
    public int EvaluacionGlobalId { get; set; }

    [Column("evaluacion_id", TypeName = "int(11)")]
    public int EvaluacionId { get; set; }

    [Column("ciclo_lectivo_id", TypeName = "int(11)")]
    public int? CicloLectivoId { get; set; }

    [Column("nivel")]
    [StringLength(50)]
    public string? Nivel { get; set; }

    [Column("asignatura")]
    [StringLength(50)]
    public string? Asignatura { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("EvaluacionId")]
    [InverseProperty("PtConvalidacionEvaluacions")]
    public virtual PtEvaluacion Evaluacion { get; set; } = null!;

    [ForeignKey("EvaluacionGlobalId")]
    [InverseProperty("PtConvalidacionEvaluacions")]
    public virtual PtEvaluacionGlobal EvaluacionGlobal { get; set; } = null!;
}
