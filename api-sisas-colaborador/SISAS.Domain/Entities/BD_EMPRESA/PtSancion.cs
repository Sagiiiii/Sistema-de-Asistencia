using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_sancion")]
public partial class PtSancion
{
    [Key]
    [Column("id_sancion", TypeName = "int(11)")]
    public int IdSancion { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("puntos")]
    [Precision(8, 4)]
    public decimal? Puntos { get; set; }

    /// <summary>
    /// VERBAL = 1, SUMATORIA = 2, SUSPENSIÓN= 3
    /// </summary>
    [Column("tipo", TypeName = "int(11)")]
    public int? Tipo { get; set; }

    [Column("dias_suspension", TypeName = "int(11)")]
    public int? DiasSuspension { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Sancion")]
    public virtual ICollection<PtInfraccion> PtInfraccions { get; set; } = new List<PtInfraccion>();
}
