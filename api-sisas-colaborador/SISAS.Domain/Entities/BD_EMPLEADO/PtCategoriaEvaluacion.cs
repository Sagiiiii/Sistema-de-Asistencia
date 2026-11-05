using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_categoria_evaluacion")]
public partial class PtCategoriaEvaluacion
{
    [Key]
    [Column("id_categoria_evaluacion", TypeName = "int(11)")]
    public int IdCategoriaEvaluacion { get; set; }

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

    /// <summary>
    /// PENDIENTE = 1; HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "tinyint(4)")]
    public sbyte? Estado { get; set; }

    [Column("detalles")]
    [StringLength(1000)]
    public string? Detalles { get; set; }

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

    [InverseProperty("CategoriaEvaluacion")]
    public virtual ICollection<PtEvaluacion> PtEvaluacions { get; set; } = new List<PtEvaluacion>();
}
