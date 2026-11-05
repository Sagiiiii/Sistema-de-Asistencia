using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_categoria_evaluacion_global")]
public partial class PtCategoriaEvaluacionGlobal
{
    [Key]
    [Column("id_categoria_evaluacion_global", TypeName = "int(11)")]
    public int IdCategoriaEvaluacionGlobal { get; set; }

    [Column("codigo", TypeName = "int(11)")]
    public int? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column("nombre_corto")]
    [StringLength(50)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(50)]
    public string? NombreLargo { get; set; }

    /// <summary>
    /// PENDIENTE; HABILITADO, DESHABILITADO
    /// </summary>
    [Column("estado")]
    [StringLength(50)]
    public string Estado { get; set; } = null!;

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

    [Column("delated_at", TypeName = "datetime")]
    public DateTime? DelatedAt { get; set; }

    [InverseProperty("CategoriaEvaluacionGlobal")]
    public virtual ICollection<PtEvaluacionGlobal> PtEvaluacionGlobals { get; set; } = new List<PtEvaluacionGlobal>();
}
